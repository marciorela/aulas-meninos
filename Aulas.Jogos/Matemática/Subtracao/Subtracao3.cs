﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulas.Jogos.Matemática.Subtracao
{
	public class Subtracao3 : Jogo
	{
		private const int maxNumber = 1000;

		public override string Titulo => "Quanto é?";

		public override string Descricao => $"Subtração 3: Números abaixo de {maxNumber}";

		public override void PreparaPergunta(IConfiguration config)
		{
			int[] digitsRandom = { maxNumber - 1, maxNumber - 1};
			var digits = new List<int>();

			string expr;
			int total;
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
			} while (digits[1] > digits[0] || total < 0);
			expr = expr[..^3];

			Pergunta = expr.Trim();
			Resposta.Add(total.ToString());
		}

	}
}
