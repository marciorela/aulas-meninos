using Microsoft.Extensions.Configuration;

namespace Aulas.Jogos.Soma
{
    public class SomaNivel0 : Jogo
    {
        private string _pergunta = "";
        private string _resposta = "";

        public override string Pergunta => _pergunta;

        public override string Resposta => _resposta;

        public override string Titulo => "Quanto é?";

        public override string Descricao => "Soma Simples: Dois números com um algarismo cada.";

        public SomaNivel0()
        {
        }

        public override void PreparaPergunta(IConfiguration config)
        {
            int[] digitsRandom = { 9, 9 };

            string expr;
            int total;
            do
            {
                expr = "";
                total = 0;
                foreach (var digitRandom in digitsRandom)
                {
                    var digit = new Random().Next(digitRandom + 1);

                    total += digit;
                    expr += digit.ToString() + " + ";
                }
            } while (total == 0);
            expr = expr[..^3];

            _pergunta = expr.Trim();
            _resposta = total.ToString();
        }
    }
}