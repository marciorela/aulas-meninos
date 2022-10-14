using Aulas.Domain.Models;
using Aulas.Extensions;
using Aulas.Jogos;
using Aulas.Jogos.Soma;
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
        public bool[] Checks { get; set; }

        public List<Jogo> Tipos { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {

            if (Request.Cookies.TryGetValue("Nome", out string nome))
            {
                Jogador.Nome = nome;
            }

            TipoJogo.Filter(new());
            Tipos = TipoJogo.ListInstances();

            if (Request.Cookies.TryGetValue("Opcoes", out string opcoes))
            {
                var listOpcoes = opcoes.Split(',').ToList();
                Checks = Tipos.Select(x => listOpcoes.Any(y => y == x.GetType().ToString())).ToArray();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            Tipos = TipoJogo.ListInstances();

            if (string.IsNullOrWhiteSpace(Jogador.Nome))
            {
                return Page();
            }
            else if (!Checks.Any(x => x))
            {
                ErrorMessage = "Informe pelo menos uma opção!";
                return Page();
            }

            _partida = new Partida(new Jogador());

            var listOpcoes = new List<string>();
            for (int i = 0; i < Checks.Length; i++)
            {
                if (Checks[i])
                {
                    listOpcoes.Add(Tipos[i].GetType().ToString());
                }
            }
            var opcoes = string.Join(",", listOpcoes);

            SaveCookie(opcoes);

            TipoJogo.Filter(listOpcoes);

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
}