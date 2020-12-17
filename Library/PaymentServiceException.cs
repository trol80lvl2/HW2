using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class PaymentServiceException : ApplicationException
    {
        public PaymentServiceException() : base()
        {

        }
        public PaymentServiceException(string message) : base(message) { }
        public PaymentServiceException(string message, Exception inner) : base(message, inner) { }
    }
}
