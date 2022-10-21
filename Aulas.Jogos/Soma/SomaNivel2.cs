namespace Aulas.Jogos.Soma
{
    public class SomaNivel2 : Jogo
    {
        private string _pergunta = "";
        private string _resposta = "";

        public override string Pergunta => _pergunta;

        public override string Resposta => _resposta;

        public override string Titulo => "Soma 2";

        public override string Descricao => $"{Titulo}: Dois números cuja somatória seja inferior a 100.";

        public override void PreparaPergunta()
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

            _pergunta = expr.Trim();
            _resposta = total.ToString();
        }
    }
}