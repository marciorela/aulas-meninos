using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulas.Web.Models
{
    public abstract class OperacaoBase
    {

        private List<int> _digits = new();

        public IReadOnlyList<int> Digits { get { return _digits; } }

        public string OperatorStr { get; protected set; } = "";

        public abstract int Results();

        public OperacaoBase()
        {
            _digits = new List<int>();
        }

        public void AddDigits(params int[] digits)
        {
            foreach (int digit in digits)
            {
                _digits.Add(digit);
            }
        }

        public void Random(int qtdDigits, int maxValues = 100)
        {
            _digits.Clear();
            for (var i = 0; i < qtdDigits; i++)
            {
                _digits.Add(new Random().Next(maxValues));
            }
        }

    }
}
