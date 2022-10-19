using Aulas.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Aulas.Services;
using Aulas.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Aulas.Web.Pages
{
    public class PartidaModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Por favor, informe o resultado")]
        public string Resultado { get; set; }

        private Partida _partida;
        public readonly ILogger _logger;

        public Partida Partida { get
            {
                if (_partida is null)
                {
                    if (HttpContext is not null)
                    {
                        _partida = Partida.ReadFromSession(HttpContext.Session);
                    }
                }

                return _partida;
            }
        }

        public PartidaModel(ILogger<PartidaModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            if (Partida is null)
            {
                return RedirectToPage("Index");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (Partida is null)
            {
                // FIM DA SESSÃO
                return RedirectToPage("Index");
            }

            if (ModelState.IsValid && !Partida.FimDePartida())
            {
                Partida.NovaResposta(Resultado.ToString());
                Partida.SaveToSession(HttpContext.Session);
            }

            // EVITAR O REENVIO DO FORMULÁRIO AO PRESSIONAR F5 NO BROWSER
            return RedirectToPage("Partida");
        }

        public IActionResult OnGetReiniciar()
        {
            if (Partida is null)
            {
                // FIM DA SESSÃO
                return RedirectToPage("Index");
            }

            Partida.Iniciar();
            Partida.SaveToSession(HttpContext.Session);

            return Page();
        }

        public override PageResult Page()
        {
            ViewData["Name"] = Partida.Jogador.Nome;
            ViewData["PodeReiniciar"] = (Partida.FimDePartida() ? "N" : "S");

            return base.Page();
        }
    }
}
