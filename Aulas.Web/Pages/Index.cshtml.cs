using Aulas.Domain.Models;
using Aulas.Extensions;
using Aulas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aulas.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

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

            var partida = new Partida(Jogador);

            HttpContext.Session.Set<Partida>("Partida", partida);
            
            return RedirectToPage("Somar");
        }
    }
}