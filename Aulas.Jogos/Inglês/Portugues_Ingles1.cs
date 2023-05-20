using Aulas.Domain.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulas.Jogos.Inglês
{
    public class Portugues_Ingles1 : Jogo
    {
        private readonly List<PerguntaResposta> _palavras = new()
        {
            new PerguntaResposta("Casa", "House")
        };

        public override bool Enabled => false;
        public override ETipoPergunta TipoPergunta => ETipoPergunta.String;
        public override ETipoResposta TipoResposta => ETipoResposta.Text;
        public override string Titulo => "Português => Inglês";
        public override string Descricao => "Português - Inglês 1 - Escreva a palavra em Inglês";
        public override int MaxPerguntas => _palavras.Count;

        public override void PreparaPergunta(IConfiguration config)
        {
            var random = new Random().Next(MaxPerguntas);

            Pergunta = _palavras[random].Pergunta;
            Resposta.Add(_palavras[random].Resposta);
        }
    }
}
