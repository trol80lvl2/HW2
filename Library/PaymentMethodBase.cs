using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public abstract class PaymentMethodBase
    {
        public string Name { get; set; }

        public decimal AmountLimit { get; set; } = decimal.MaxValue;
        public decimal OneTImeLimit { get; set; } = decimal.MaxValue;
    }
}
