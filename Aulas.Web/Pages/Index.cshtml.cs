﻿using Aulas.Domain.Models;
using Aulas.Extensions;
using Aulas.Jogos;
using Aulas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Net.Http.Headers;

namespace Aulas.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private Partida _partida;

        public string ErrorMessage = "";

        [BindProperty]
        public Jogador Jogador { get; set; } = new();

        [BindProperty]
        public List<TipoChecked> Checks { get; set; } = new();

        private List<Jogo> Tipos { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            _logger.LogInformation("Iniciando aplicação");

            if (Request.Cookies.TryGetValue("Nome", out string nome))
            {
                Jogador.Nome = nome;
            }

            if (!Request.Cookies.TryGetValue("Opcoes", out string opcoes))
            {
                opcoes = "";
            }

            var listOpcoes = opcoes.Split(',').ToList();
            GetTipoChecked(listOpcoes);

            return Page();
        }

        private void GetTipoChecked(List<string> listOpcoes)
        {
            Tipos = TipoJogo.ListInstances(new());

            Checks = Tipos.Select(x => new TipoChecked()
            {
                Descricao = x.Descricao,
                ClassName = x.GetType().ToString(),
                Checked = listOpcoes.Any(o => o == x.GetType().ToString())
            }).ToList();
        }

        public IActionResult OnPost()
        {

            if (!Checks.Any(x => x.Checked))
            {
                ErrorMessage = "Informe pelo menos uma opção!";
                GetTipoChecked(new());
                return Page();
            }


            var listOpcoes = new List<string>();
            for (int i = 0; i < Checks.Count; i++)
            {
                if (Checks[i].Checked)
                {
                    listOpcoes.Add(Checks[i].ClassName);
                }
            }
            var opcoes = string.Join(",", listOpcoes);

            _logger.LogInformation("Key:{sessionId}, iniciando partida: {nome}, {opcoes}", HttpContext.Session.Id, Jogador.Nome, opcoes);
            SaveCookie(opcoes);

            _partida = new Partida(new Jogador());
            _partida.FiltroJogos.AddRange(listOpcoes);
            _partida.Iniciar();
            _partida.Jogador.Nome = Jogador.Nome;
            _partida.SaveToSession(HttpContext.Session);

            return RedirectToPage("Partida");
        }

        private void SaveCookie(string opcoes)
        {
            var options = new CookieOptions()
            {
                Expires = DateTime.Now.AddYears(50)
            };

            Response.Cookies.Append("Opcoes", opcoes, options);
            Response.Cookies.Append("Nome", Jogador.Nome, options);
        }
    }

    public class TipoChecked
    {
        public string Descricao { get; set; }
        public string ClassName { get; set; }
        public bool Checked { get; set; }
    }
}