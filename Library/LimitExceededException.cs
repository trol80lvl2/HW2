using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class LimitExceededException : PaymentServiceException
    {
        public decimal Value { get; private set; }
        public LimitExceededException() : base()
        {

        }
        public LimitExceededException(string message) : base(message) { }
        public LimitExceededException(string message, decimal value) : base(message) {
            Value = value;
        }
        public LimitExceededException(string message, Exception inner) : base(message, inner) { }
    }
}
