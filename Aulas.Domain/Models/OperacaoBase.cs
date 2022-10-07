using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulas.Domain.Models
{
    public abstract class OperacaoBase : IJogo
    {

        private List<int> _digits = new();

        public IReadOnlyList<int> Digits { get { return _digits; } }

        public string OperatorStr { get; protected set; } = "";

        public abstract int Result();

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

        public void Random(params int[] digitsRandom)
        {
            _digits.Clear();
            foreach (var digitRandom in digitsRandom)
            {
                _digits.Add(new Random().Next(digitRandom+1));
            }
        }

        public virtual string ExpressionNoResult()
        {
            var expr = "";
            foreach (var digit in Digits)
            {
                expr += digit.ToString() + " " + OperatorStr + " ";
            }
            expr = expr.Substring(0, expr.Length - OperatorStr.Length-2);

            return expr.Trim();
        }

        public virtual string ExpressionWithResult()
        {
            return ExpressionNoResult() + " = " + Result().ToString();
        }
    }
}
