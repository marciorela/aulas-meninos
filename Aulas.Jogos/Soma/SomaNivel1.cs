namespace Aulas.Jogos.Soma
{
    public class SomaNivel1 : Jogo
    {
        private readonly string _pergunta = "";
        private readonly string _resposta = "";

        public override string Pergunta => _pergunta;

        public override string Resposta => _resposta;

        public override string Titulo => "Soma Nivel 1";

        public override string Descricao => "Soma Nível 1: O primeiro número até 90 e o segundo número até 9.";

        public SomaNivel1()
        {
            var total = 0;
            int[] digitsRandom = { 90, 9 };
            var digits = new List<int>();

            foreach (var digitRandom in digitsRandom)
            {
                digits.Add(new Random().Next(digitRandom + 1));
            }

            var expr = "";
            foreach (var digit in digits)
            {
                total += digit;
                expr += digit.ToString() + " + ";
            }
            expr = expr.Substring(0, expr.Length - 3);

            _pergunta = expr.Trim();
            _resposta = total.ToString();
        }

    }
}