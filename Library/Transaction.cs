using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Transaction
    {
        public int AccountId { get; set; }
        public string BankName { get; set; }
        public decimal Amount { get; set; }
    }
}
