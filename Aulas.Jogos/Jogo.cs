using Aulas.Domain.Enums;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace Aulas.Jogos
{
    public class Jogo
    {
        public virtual bool Enabled { get; set; } = true;

        public virtual ETipoPergunta TipoPergunta { get; set; } = ETipoPergunta.String;

        public virtual ETipoResposta TipoResposta { get; set; } = ETipoResposta.Numeric;

        public virtual string Template { get; set; } = "";

        public virtual string Pergunta { get; set; } = "Pergunta não definida";

        public virtual List<string> Resposta { get; set; } = new();

        public virtual string Titulo { get; set; } = "Titulo não definido";

        public virtual string Descricao { get; set; } = "Descricao não definida";
        
        public virtual string PerguntaStyle { get; set; } = "font-size: 50px";

        public virtual int MaxPerguntas { get; set; } = 1000;

        public string RespostaInformada { get; set; } = "";

        public bool Acerto
        {
            get
            {
                return Resposta.Any(x => x.ToLower().Equals(RespostaInformada.Trim().ToLower()));
            }
        }

        public virtual void PreparaPergunta(IConfiguration config)
        {

        }

        public void GravarResposta(string resposta)
        {
            RespostaInformada = resposta;
        }

        protected void SubstituiTemplate()
        {
            Template = Pergunta;

            // PEGA TODOS OS TERMOS <....>
            var regex = new Regex(@"\<[^\>]+?\>");
            var list = regex.Matches(Pergunta);
            foreach (var match in list)
            {
                var str = match.ToString()!.Replace("<", "").Replace(">", "");
                var items = str.Split(":");

                var nvar = items[0];
                var interval = items[1].Split("-");

                var number = new Random().Next(Int32.Parse(interval[0]), Int32.Parse(interval[1]) + 1);

                Template = Template.Replace(match.ToString()!, "?");
                Pergunta = Pergunta.Replace(match.ToString()!, number.ToString());
                for (int i = 0; i < Resposta.Count(); i++)
                {
                    Resposta[i] = Resposta[i].Replace("<" + nvar + ">", number.ToString());
                }
            }

            var data = new DataTable();
            for (int i = 0; i < Resposta.Count(); i++)
            {
                Resposta[i] = data.Compute(Resposta[i], "").ToString()!;
            }
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
