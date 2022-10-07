﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulas.Domain.Models
{
    public class Soma : OperacaoBase
    {
        public Soma()
        {
            OperatorStr = "+";
        }

        public override int Result()
        {
            var result = 0;
            foreach (var digit in Digits)
            {
                result += digit;
            }

            return result;
        }
    }
}