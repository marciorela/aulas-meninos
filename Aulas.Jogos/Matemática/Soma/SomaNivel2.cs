using Microsoft.Extensions.Configuration;

namespace Aulas.Jogos.Matemática.Soma
{
    public class SomaNivel2 : Jogo
    {
        public override string Titulo => "Quanto é?";

        public override string Descricao => "Soma 2: Dois números cuja somatória seja inferior a 100.";

        public override void PreparaPergunta(IConfiguration config)
        {
            int[] digitsRandom = { 99, 99 };

            int total;
            string expr;
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
            } while (total == 0 || total >= 100);
            expr = expr[..^3];

            Pergunta = expr.Trim();
            Resposta.Add(total.ToString());
        }
    }
}