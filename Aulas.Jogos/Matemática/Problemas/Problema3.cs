using Aulas.Domain.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulas.Jogos.Matemática.Problemas
{
    public class Problema3 : Jogo
    {
        private List<PerguntaResposta> _list = new()
        {
            new PerguntaResposta("Samara gosta muito de biscoitos. Ela come <n1:2-4> biscoitos por dia. Quantos biscoitos ela come em uma semana?", "<n1> * 7"),
            new PerguntaResposta("Bia tinha <n1:8-12> balas e chupou <n2:1-4>. Paulo lhe deu mais <n3:3-6>. Quantas balas ela ainda tem?", "<n1> - <n2> + <n3>"),
            new PerguntaResposta("Papai Noel estava com <n1:50-60> brinquedos em seu trenó. Ele já entregou <n2:20-30>. Quantos brinquedos ainda faltam entregar?", "<n1> - <n2>"),
            new PerguntaResposta("Papai Noel tinha <n1:20-60> renas e nasceram <n2:20-30>. Quantas renas tem agora?", "<n1> + <n2>"),
            new PerguntaResposta("Na casa de Matheus tem <n1:8-12> laranjeiras, <n2:2-4> mangueiras, <n3:2-5> limoeiros, <n4:10-12> goiabeiras e <n5:2-4> bananeiras. Quantas árvores tem no total?", "<n1> + <n2> + <n3> + <n4> + <n5>"),
            new PerguntaResposta("Se a previsão é de que o dia amanheça em <n1:18-22>ºC e passe para <n2:28-34>ºC ao longo do dia. Quantos graus irá subir?", "<n2> - <n1>"),
            new PerguntaResposta("Alice convidou <n1:80-99> crianças para sua festa de aniversário. <n2:60-79> crianças confirmaram presença. Quantas crianças não vão participar?", "<n2> - <n1>"),
            new PerguntaResposta("Para entrar em casa, João precisa subir <n1:15-20> degraus. Da hora em que acorda até a hora de dormir, ele sobe esses degraus <n2:2-4> vezes. Quantos degraus João sobe por dia?", "<n1> * <n2>"),
        };

        public override bool Enabled => true;
        public override ETipoPergunta TipoPergunta => ETipoPergunta.String;
        public override ETipoResposta TipoResposta => ETipoResposta.Numeric;
        public override string Titulo => "Resolva o problema:";
        public override string Descricao => "Nível 3: Problemas matemáticos";
        public override int MaxPerguntas => _list.Count;
        public override string PerguntaStyle => "font-size: 30px";

        public override void PreparaPergunta(IConfiguration config)
        {
            var random = new Random().Next(MaxPerguntas);

            Pergunta = _list[random].Pergunta;
            Resposta.Add(_list[random].Resposta);

            SubstituiTemplate();
        }

        public class PerguntaResposta
        {
            public string Pergunta { get; set; }
            public string Resposta { get; set; }

            public PerguntaResposta(string pergunta, string resposta)
            {
                Pergunta = pergunta;
                Resposta = resposta;
            }
        }
    }
}
