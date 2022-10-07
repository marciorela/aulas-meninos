using Aulas.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Aulas.Services;
using Aulas.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Aulas.Web.Pages
{
    public class SomarModel : PageModel
    {
        [BindProperty]
        public Soma Operacao { get; set; } = new Soma();

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

        public SomarModel(IConfiguration config)
        {
            GenerateNumbers();
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

            if (ModelState.IsValid && !Partida.FimDeJogo())
            {
                Partida.NovaJogada(Operacao.ExpressionNoResult() + " = " + Resultado.ToString(), Resultado == Operacao.Result());
                Partida.SaveToSession(HttpContext.Session);

                SetDataBeforeRender();
                GenerateNumbers();
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

        private void GenerateNumbers()
        {
            Operacao.Random(90, 9);
        }

        private void SetDataBeforeRender()
        {
            ViewData["Name"] = Partida.Jogador.Nome;
        }

    }
}
