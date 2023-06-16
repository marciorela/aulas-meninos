using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulas.Jogos.Matemática.Tabuada;

public class Tabuada9 : Jogo
{
	private const int tabuada = 9;

	public override string Titulo => "Quanto é?";

	public override string Descricao => $"Tabuada do {tabuada}";

	public override int MaxPerguntas => 10;

	public override void PreparaPergunta(IConfiguration config)
	{
		string expr;
		int total;

		var digit = new Random().Next(10) + 1;

		expr = $"{tabuada} x {digit}";
		total = tabuada * digit;

		Pergunta = expr.Trim();
		Resposta.Add(total.ToString());
	}
}
