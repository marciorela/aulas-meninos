﻿namespace Aulas.Jogos.Soma
{
    public class SomaNivel0 : Jogo
    {
        private readonly string _pergunta = "";
        private readonly string _resposta = "";

        public override string Pergunta => _pergunta;

        public override string Resposta => _resposta;

        public override string Titulo => "Soma Simples";

        public override string Descricao => $"{Titulo}: Dois números com um algarismo cada.";

        public SomaNivel0()
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