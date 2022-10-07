using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulas.Domain.Models
{
    public class Jogada
    {
        public string Expressao { get; }
        public bool Acerto { get; }

        public Jogada(string expressao, bool acerto)
        {
            Expressao = expressao;
            Acerto = acerto;
        }

    }
}
