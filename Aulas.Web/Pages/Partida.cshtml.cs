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
        public int Resultado { get; set; }

        private Partida _partida;

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

        public PartidaModel(IConfiguration config)
        {
        }

        public void OnGet()
        {
            SetDataBeforeRender();
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

                SetDataBeforeRender();
            }

            return Page();
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

        private void SetDataBeforeRender()
        {
            ViewData["Name"] = Partida.Jogador.Nome;
        }

    }
}
