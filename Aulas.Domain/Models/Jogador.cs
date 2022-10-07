using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulas.Domain.Models
{
    public class Jogador
    {
        [Required(ErrorMessage = "Nome deve ser informado")]
        [StringLength(40)]
        [Display(Name = "Informe seu nome")]
        public string? Nome { get; set; }
    }
}
