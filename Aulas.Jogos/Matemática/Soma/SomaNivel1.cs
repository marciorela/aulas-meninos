using Microsoft.Extensions.Configuration;

namespace Aulas.Jogos.Matematica.Soma
{
    public class SomaNivel1 : Jogo
    {
        public override string Titulo => "Quanto é?";

        public override string Descricao => "Soma 1: O primeiro número até 90 e o segundo número até 9.";

        public override void PreparaPergunta(IConfiguration config)
        {
            int[] digitsRandom = { 90, 9 };

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

            Pergunta = expr.Trim();
            Resposta.Add(total.ToString());
        }
    }
}