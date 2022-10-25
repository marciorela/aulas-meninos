using Aulas.Domain.Enums;
using Microsoft.Extensions.Configuration;

namespace Aulas.Jogos
{
    public class Jogo
    {
        public virtual bool Enabled { get; set; } = true;

        public virtual ETipoPergunta TipoPergunta { get; set; } = ETipoPergunta.String;

        public virtual ETipoResposta TipoResposta { get; set; } = ETipoResposta.Numeric;

        public virtual string Pergunta { get; set; } = "Pergunta não definida";

        public virtual string Resposta { get; set; } = "Resposta não definida";

        public virtual string Titulo { get; set; } = "Titulo não definido";

        public virtual string Descricao { get; set; } = "Descricao não definida";

        public virtual int MaxPerguntas { get; set; } = int.MaxValue;

        public bool Acerto
        {
            get
            {
                return Resposta.ToLower().Equals(RespostaInformada.Trim().ToLower());
            }
        }

        public string RespostaInformada { get; set; } = "";

        public virtual void PreparaPergunta(IConfiguration config)
        {

        }

        public void GravarResposta(string resposta)
        {
            RespostaInformada = resposta;
        }

        public Jogo()
        {
        }

    }
    class FromSettings
    {
        public string? Resposta { get; set; }
        public string? Link { get; set; }
    }
}
