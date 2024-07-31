﻿using SOLIDHomework.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Payment
{
    public class OtherCountryTaxCalculator : ITaxCalculator
    {
        public decimal ApplyTax(decimal amount)
        {
            return amount * 1.1M;
        }
    }
}
