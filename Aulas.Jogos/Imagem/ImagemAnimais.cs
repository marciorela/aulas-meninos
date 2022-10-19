using Aulas.Domain.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulas.Jogos.Imagem
{
    public class ImagemAnimais: Jogo
    {
        private readonly string _pergunta;
        private readonly string _resposta;

        private readonly List<FromSettings> Link = new();

        public override bool Enabled => false;

        public override string Pergunta => _pergunta;

        public override string Resposta => _resposta;

        public override string Titulo => "Imagem - Animais";

        public override string Descricao => "Informar o nome dos animais a partir de imagens.";

        public override ETipoPergunta TipoPergunta => ETipoPergunta.Imagem;

        public override ETipoResposta TipoResposta => ETipoResposta.Text;

        public ImagemAnimais()
        {
            Link = _config.GetSection("Imagens:Animais").Get<List<FromSettings>>();

            var indexPergunta = new Random().Next(Link.Count);

            _pergunta = Link[indexPergunta].Link!;
            _resposta = Link[indexPergunta].Resposta!;
        }

    }
}
