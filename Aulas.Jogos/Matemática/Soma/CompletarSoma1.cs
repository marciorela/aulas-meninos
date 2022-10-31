using Microsoft.Extensions.Configuration;

namespace Aulas.Jogos.Matemática.Soma
{
    public class CompletarSoma1 : Jogo
    {
        public override string Titulo => "Complete a expressão:";

        public override string Descricao => "Complete a soma: O primeiro número até 90 e o segundo número até 9.";

        public override void PreparaPergunta(IConfiguration config)
        {
            int[] digitsRandom = { 90, 9 };

            string expr;
            int total;
            do
            {
                expr = "";
                total = 0;
                for (int i = 0; i < digitsRandom.Length; i++)
                {
                    var digit = new Random().Next(digitsRandom[i] + 1);
                    total += digit;

                    if (i == 1)
                    {
                        expr += " ? + ";
                        Resposta.Clear();
                        Resposta.Add(digit.ToString());
                    }
                    else
                    {
                        expr += digit.ToString() + " + ";
                    }
                }
            } while (total == 0);
            expr = expr[..^3];
            expr += $" = {total}";

            Pergunta = expr.Trim();
            Resposta.Add(total.ToString());
        }
    }
}