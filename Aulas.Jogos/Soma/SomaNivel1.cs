namespace Aulas.Jogos.Soma
{
    public class SomaNivel1 : Jogo
    {
        private string _resposta = "";

        public override string Descricao()
        {
            return "Soma Nível 1: O primeiro número até 90 e o segundo número até 9.";
        }

        public override string Titulo()
        {
            return "Soma Nivel 1";
        }

        public override string Pergunta()
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

            _resposta = total.ToString();

            return expr.Trim();
        }

        public override string Resposta()
        {
            return _resposta;
        }

    }
}