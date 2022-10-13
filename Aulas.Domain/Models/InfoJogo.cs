using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulas.Domain.Models
{
    public class InfoJogo
    {

        public string Pergunta { get; set; } = "";

        public string RespostaPergunta { get; set; } = "";

        public string RespostaInformada { get; set; } = "";
        
        public bool Acerto
        {
            get
            {
                return RespostaPergunta.Equals(RespostaInformada);
            }
        }

        public InfoJogo()
        {

        }

        public InfoJogo(string pergunta, string resposta)
        {
            Pergunta = pergunta;
            RespostaPergunta = resposta;
        }

        public void GravarResposta(string resposta)
        {
            RespostaInformada = resposta;
        }
    }
}
