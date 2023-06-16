using Aulas.Domain.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulas.Jogos.CIências
{
	public class Teste1 : Jogo
	{
		private readonly List<UnicaEscolha> _list = new()
			{
				new UnicaEscolha("Pergunta 1?", new List<UnicaResposta>() {
					new UnicaResposta("Resposta errada 1", false),
					new UnicaResposta("Resposta errada 2", false),
					new UnicaResposta("Resposta errada 3", false),
					new UnicaResposta("Resposta certa 1", true),
					new UnicaResposta("Resposta certa 2", true)
				})
			};

		public override bool Enabled => false;
		public override ETipoPergunta TipoPergunta => ETipoPergunta.String;
		public override ETipoResposta TipoResposta => ETipoResposta.Numeric;
		public override string Titulo => "Escolha uma das alternativas:";
		public override string Descricao => "Nível 1: Ciências";
		public override int MaxPerguntas => _list.Count;
		public override string PerguntaStyle => "font-size: 30px";

		public override void PreparaPergunta(IConfiguration config)
		{
			var random = new Random().Next(MaxPerguntas);

			Pergunta = _list[random].Pergunta;
			//Resposta.Add(_list[random].Resposta);

			SubstituiTemplate();
		}

	}

	public class UnicaEscolha
	{
		public string Pergunta { get; set; } = "";
		public List<UnicaResposta> Respostas { get; set; } = new();

		public UnicaEscolha(string pergunta, List<UnicaResposta> respostas)
		{
			Pergunta = pergunta;
			Respostas = respostas;
		}
    }
				
	public class UnicaResposta
	{
		public string TextoResposta { get; set; } = "";
        public bool RespostaCorreta { get; set; }

		public UnicaResposta(string textoResposta, bool respostaCorreta)
		{
			TextoResposta = textoResposta;
			RespostaCorreta = respostaCorreta;
		}
    }
}
