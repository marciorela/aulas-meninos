using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulas.Jogos.Matemática.Subtracao
{
	public class Subtracao1 : Jogo
	{
		private const int maxNumber = 30;

		public override string Titulo => "Quanto é?";

		public override string Descricao => $"Subtração 1: Números abaixo de {maxNumber}. Algarismos maiores";

		public override void PreparaPergunta(IConfiguration config)
		{
			int[] digitsRandom = { maxNumber - 1, maxNumber - 1};
			var digits = new List<int>();

			string expr;
			int total;
			bool digitError;
			do
			{
				expr = "";
				digits.Clear();
				foreach (var digitRandom in digitsRandom)
				{
					var digit = new Random().Next(digitRandom + 1);
					digits.Add(digit);

					expr += digit.ToString() + " - ";
				}

				total = digits[0] - digits[1];

				// VERIFICA SE TODOS OS DÍGITOS DO PRIMEIRO NÚMERO SÃO MAIORES QUE O SEGUNDO NÚMERO
				digitError = false;
				for (var i=0; i < 10; i++)
				{
					if (digits[0].ToString().PadLeft(10, '0')[i] < digits[1].ToString().PadLeft(10, '0')[i])
					{
						digitError = true;
					}
				}

			} while (digits[1] > digits[0] || total < 0 || digitError);
			expr = expr[..^3];

			Pergunta = expr.Trim();
			Resposta.Add(total.ToString());
		}

	}
}
