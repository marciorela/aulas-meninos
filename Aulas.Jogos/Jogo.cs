using Aulas.Domain.Enums;
using Microsoft.Extensions.Configuration;

namespace Aulas.Jogos
{
    public class Jogo
    {
        protected IConfiguration _config;

        public virtual bool Enabled { get; set; } = true;

        public virtual ETipoPergunta TipoPergunta { get; set; } = ETipoPergunta.String;

        public virtual ETipoResposta TipoResposta { get; set; } = ETipoResposta.Numeric;

        public virtual string Pergunta { get; set; } = "Pergunta não definida";

        public virtual string Resposta { get; set; } = "Resposta não definida";

        public virtual string Titulo { get; set; } = "Titulo não definido";

        public virtual string Descricao { get; set; } = "Descricao não definida";

        public bool Acerto
        {
            get
            {
                return Resposta.ToLower().Equals(RespostaInformada.ToLower());
            }
        }

        public string RespostaInformada { get; set; } = "";

        public void GravarResposta(string resposta)
        {
            RespostaInformada = resposta;
        }

        public Jogo()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory)!.FullName)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                //.AddEnvironmentVariables()
                .Build();
        }

    }
    class FromSettings
    {
        public string? Resposta { get; set; }
        public string? Link { get; set; }
    }
}
