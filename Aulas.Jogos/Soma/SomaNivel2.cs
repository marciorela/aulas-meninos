﻿namespace Aulas.Jogos.Soma
{
    //public class SomaNivel2 : IJogo
    //{
    //    private string _resposta = "";

    //    public override string Pergunta()
    //    {
    //        string expr;
    //        var total = 0;
    //        int[] digitsRandom = { 99, 99 };
    //        var digits = new List<int>();

    //        while (true)
    //        {

    //            digits.Clear();
    //            foreach (var digitRandom in digitsRandom)
    //            {
    //                digits.Add(new Random().Next(digitRandom + 1));
    //            }

    //            expr = "";
    //            total = 0;
    //            foreach (var digit in digits)
    //            {
    //                total += digit;
    //                expr += digit.ToString() + " + ";
    //            }
    //            expr = expr.Substring(0, expr.Length - 3);

    //            if (total < 100)
    //            {
    //                break;
    //            }

    //        }
    //        _resposta = total.ToString();

    //        return expr.Trim();
    //    }

    //    public override string Resposta()
    //    {
    //        return _resposta;
    //    }

    //}
}