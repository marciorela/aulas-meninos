using Aulas.Domain.Models;
using Aulas.Extensions;
using Aulas.Jogos.Soma;
using Aulas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aulas.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private Partida _partida;

        [BindProperty]
        public Jogador Jogador { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            //if (!string.IsNullOrWhiteSpace(HttpContext.Session.GetString("Nome"))) {
            //    return RedirectToPage("Somar");
            //}

            

            return Page();
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Jogador.Nome))
            {
                return Page();                     
            }

            _partida = new Partida(new Jogador());
            _partida.Iniciar();
            //_partida.Jogos.Add(new SomaNivel1());
//            _partida.SaveToSession(HttpContext.Session);

//            _partida = Partida.ReadFromSession(HttpContext.Session);
            _partida.Jogador.Nome = Jogador.Nome;
            _partida.SaveToSession(HttpContext.Session);

            return RedirectToPage("Partida");
        }
    }
}