namespace Aulas.Jogos.Soma
{
    public class SomaNivel2 : Jogo
    {
        private readonly string _pergunta = "";
        private readonly string _resposta = "";

        public override string Pergunta => _pergunta;

        public override string Resposta => _resposta;

        public override string Titulo => "Soma Nivel 2";

        public override string Descricao => "Soma Nível 2: Dois números cuja somatória seja inferior a 100.";

        public SomaNivel2()
        {
            string expr;
            int[] digitsRandom = { 99, 99 };
            var digits = new List<int>();
            int total;

            while (true)
            {

                digits.Clear();
                foreach (var digitRandom in digitsRandom)
                {
                    digits.Add(new Random().Next(digitRandom + 1));
                }

                expr = "";
                total = 0;
                foreach (var digit in digits)
                {
                    total += digit;
                    expr += digit.ToString() + " + ";
                }
                expr = expr.Substring(0, expr.Length - 3);

                if (total < 100)
                {
                    break;
                }

            }
            _pergunta = expr.Trim();
            _resposta = total.ToString();
        }
    }
}