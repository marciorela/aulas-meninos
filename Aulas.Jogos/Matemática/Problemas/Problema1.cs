using Aulas.Domain.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulas.Jogos.Matemática.Problemas
{
    public class Problema1 : Jogo
    {
        private readonly List<PerguntaResposta> _list = new()
        {
            new PerguntaResposta("A mãe de Ana Laura comprou <n1:5-15> colares e <n2:5-15> anéis para revender. Quantas jóias ela comprou?", "<n1> + <n2>"),
            new PerguntaResposta("Sofia comeu <n1:2-5> brigadeiros, <n2:2-5> beijinhos e <n3:2-4> tortas de chocolate. Quantos doces ela comeu?", "<n1> + <n2> + <n3>"),
            new PerguntaResposta("O jogo Brasil e Itália pela Copa do Mundo de futebol terminou em <n1:2-3> a <n2:0-2>. Quantos gols foram feitos na partida?", "<n1> + <n2>"),
            new PerguntaResposta("Numa fazenda tem <n1:2-10> vaquinhas e <n2:2-4> bois. Quantos animais a fazenda tem no total?", "<n1> + <n2>"),
            new PerguntaResposta("O aquário de Alice possui <n1:2-8> peixinhos dourados e <n2:2-8> peixes palhaço. Quantos peixes no total Alice tem?", "<n1> + <n2>"),
            new PerguntaResposta("Pedro tem <n1:2-10> carrinhos e Fábio tem <n2:1-10>. Juntos eles tem quantos carrinhos?", "<n1> + <n2>"),
            new PerguntaResposta("Lara comprou uma boneca de <n1:9-18> reais e uma bola que custou <n2:10-20> reais. Quanto ela gastou?", "<n1> + <n2>"),
            new PerguntaResposta("Magali desenhou para sua professora <n1:2-5> abacaxis, <n2:2-5> melancias e <n3:2-5> laranjas. Quantas frutas ela desenhou?", "<n1> + <n2> + <n3>"),
            new PerguntaResposta("Rosinha encontrou um ninho com <n1:2-4> passarinhos. Chegaram mais <n2:3-8>. Quantos passarinhos tem no total?", "<n1> + <n2>"),
            new PerguntaResposta("No sítio do Chico Bento tem <n1:2-10> galinhas, <n2:2-8> vacas e <n3:4-9> patos. Quantos animais tem ao todo?", "<n1> + <n2> + <n3>"),
            new PerguntaResposta("Vinícius faz coleção de tampinhas. Ele tem <n1:8-15> amarelas e apenas <n2:2-6> verdes. Quantas tampinhas tem na coleção?", "<n1> + <n2>"),
            //new PerguntaResposta("", ""),
        };

        public override bool Enabled => true;
        public override ETipoPergunta TipoPergunta => ETipoPergunta.String;
        public override ETipoResposta TipoResposta => ETipoResposta.Numeric;
        public override string Titulo => "Resolva o problema:";
        public override string Descricao => "Nível 1: Problemas matemáticos";
        public override int MaxPerguntas => _list.Count;
        public override string PerguntaStyle => "font-size: 30px";

        public override void PreparaPergunta(IConfiguration config)
        {
            var random = new Random().Next(MaxPerguntas);

            Pergunta = _list[random].Pergunta;
            Resposta.Add(_list[random].Resposta);

            SubstituiTemplate();
        }

    }
}
