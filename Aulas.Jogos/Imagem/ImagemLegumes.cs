using Aulas.Domain.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulas.Jogos.Imagem
{
    public class ImagemLegumes: Jogo
    {
        private string _pergunta;
        private string _resposta;
        private List<FromSettings> Link = new();

        public override bool Enabled => true;

        public override string Pergunta => _pergunta;

        public override string Resposta => _resposta;

        public override string Titulo => "Imagem - Legumes";

        public override string Descricao => "Informar o nome dos legumes a partir de imagens.";

        public override ETipoPergunta TipoPergunta => ETipoPergunta.Imagem;

        public override ETipoResposta TipoResposta => ETipoResposta.Text;

        public override void PreparaPergunta(IConfiguration config)
        {
            Link = config.GetSection("Imagens:Legumes").Get<List<FromSettings>>();

            var indexPergunta = new Random().Next(Link.Count);

            _pergunta = Link[indexPergunta].Link!;
            _resposta = Link[indexPergunta].Resposta!;
        }
    }
}
