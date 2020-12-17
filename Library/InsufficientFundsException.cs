using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class InsufficientFundsException : ApplicationException
    {
        public decimal Value { get; private set; }
        public InsufficientFundsException() : base()
        {

        }
        public InsufficientFundsException(string message) : base(message) { }
        public InsufficientFundsException(string message, decimal value) : base(message)
        {
            Value = value;
        }
        public InsufficientFundsException(string message, Exception inner) : base(message, inner) { }
    }
}
