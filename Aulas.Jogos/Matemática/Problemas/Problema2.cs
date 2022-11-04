using Aulas.Domain.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aulas.Jogos.Matemática.Problemas
{
    public class Problema2 : Jogo
    {
        private readonly List<PerguntaResposta> _list = new()
        {
            new PerguntaResposta("A mãe de Ana Laura comprou <n1:25-35> colares e <n2:35-45> anéis para revender. Quantas jóias ela comprou?", "<n1> + <n2>"),
            new PerguntaResposta("Numa fazenda tem <n1:20-50> vaquinhas e <n2:20-40> bois. Quantos animais a fazenda tem no total?", "<n1> + <n2>"),
            new PerguntaResposta("Pedro tem <n1:50-60> carrinhos e Fábio tem <n2:20-39>. Juntos eles tem quantos carrinhos?", "<n1> + <n2>"),
            new PerguntaResposta("Lara comprou uma boneca de <n1:40-50> reais e uma bola que custou <n2:30-49> reais. Quanto ela gastou?", "<n1> + <n2>"),
            new PerguntaResposta("No sítio do Chico Bento tem <n1:20-40> galinhas, <n2:30-39> vacas e <n3:2-20> patos. Quantos animais tem ao todo?", "<n1> + <n2> + <n3>"),
            new PerguntaResposta("Vinícius faz coleção de tampinhas. Ele tem <n1:50-60> amarelas e apenas <n2:20-35> verdes. Quantas tampinhas tem na coleção?", "<n1> + <n2>"),

            new PerguntaResposta("Em uma cesta havia <n1:9-20> ovos de páscoa. Paulo colocou mais <n2:2-12>. Quantos ovos há na cesta agora?", "<n1> + <n2>"),
            new PerguntaResposta("No parquinho estavam <n1:9-15> crianças da turma B. Chegaram mais <n2:12-16> crianças da turma A. Quantas crianças ficaram no parquinho?", "<n1> + <n2>"),
            new PerguntaResposta("Camila foi ao supermercado e comprou 1 dezena de maçãs e 1 dúzia de peras. Quantas frutas ela comprou?", "22"),
            new PerguntaResposta("Rita tinha <n1:8-14> lápis no estojo, mas perdeu <n2:2-6>. Quantos lápis Rita tem agora?", "<n1> - <n2>"),
            new PerguntaResposta("Seu João levou <n1:5-15> balões para vender na praça. No meio do caminho <n2:2-4> estouraram. Quantos balões sobraram?", "<n1> - <n2>"),
            new PerguntaResposta("A turma do 1º ano tem <n1:8-20> alunos. Hoje, <n2:2-6> faltaram. Quantos alunos foram para a escola?", "<n1> - <n2>"),
            new PerguntaResposta("Tiago comprou <n1:4-10> brigadeiros. Ele já comeu <n2:1-3>. Quantos brigadeiros restam?", "<n1> - <n2>"),
            new PerguntaResposta("As ursinhas trabalhadeiras produzem por dia <n1:2-3> blusas, <n2:2-4> casacos e <n3:2-4> gorrinhos. Qual o total de peças elas produzem por dia?", "<n1> + <n2> + <n3>"),
            new PerguntaResposta("Dona Maria tinha <n1:8-12> ovos na geladeira. Ela fez um bolo e usou <n2:2-6> ovos. Quantos ovos ainda restam?", "<n1> - <n2>"),
            new PerguntaResposta("Numa estante tinha <n1:8-12> livros. Jorge tirou <n2:2-6> desses livros. Quantos livros ainda restam?", "<n1> - <n2>"),
            new PerguntaResposta("O ônibus da escola de Mariana tem capacidade para <n1:30-35> alunos. Hoje, apenas <n2:15-29> foram. Quantos alunos faltaram?", "<n1> - <n2>"),
            //new PerguntaResposta("", ""),
        };

        public override bool Enabled => true;
        public override ETipoPergunta TipoPergunta => ETipoPergunta.String;
        public override ETipoResposta TipoResposta => ETipoResposta.Numeric;
        public override string Titulo => "Resolva o problema:";
        public override string Descricao => "Nível 2: Problemas matemáticos";
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
