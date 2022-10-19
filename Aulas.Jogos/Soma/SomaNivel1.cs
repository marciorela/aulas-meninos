namespace Aulas.Jogos.Soma
{
    public class SomaNivel1 : Jogo
    {
        private readonly string _pergunta = "";
        private readonly string _resposta = "";

        public override string Pergunta => _pergunta;

        public override string Resposta => _resposta;

        public override string Titulo => "Soma 1";

        public override string Descricao => $"{Titulo}: O primeiro número até 90 e o segundo número até 9.";

        public SomaNivel1()
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

            _pergunta = expr.Trim();
            _resposta = total.ToString();
        }
    }
}