using Aulas.Domain.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulas.Jogos.Português.Imagem
{
    public class ImagemAnimais1: Jogo
    {
        private List<FromSettings> Link = new();

        public override bool Enabled => true;

        public override string Titulo => "Que animal é esse?";

        public override string Descricao => "Informar o nome dos animais a partir de imagens.";

        public override ETipoPergunta TipoPergunta => ETipoPergunta.Imagem;

        public override ETipoResposta TipoResposta => ETipoResposta.Text;

        public override int MaxPerguntas => Link.Count;

        public override void PreparaPergunta(IConfiguration config)
        {
            Link = config.GetSection("Imagens:Animais").Get<List<FromSettings>>();

            var indexPergunta = new Random().Next(Link.Count);

            Pergunta = Link[indexPergunta].Link!;
            Resposta.Add(Link[indexPergunta].Resposta!);
        }
    }
}
