using Aulas.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aulas.Web.Pages
{
    public class SomarModel : PageModel
    {
        [BindProperty]
        public Soma Operacao { get; set; } = new Soma();

        [BindProperty]
        public int Resultado { get; set; }

        public SomarModel()
        {
            Operacao.Random(2);
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Resultado == Operacao.Results())
            {
                Operacao.Random(2);
            }

            return Page();
        }
    }
}
