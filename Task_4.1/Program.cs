using System;
using Library;

namespace Task_4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new LimitExceededException();
            }
            catch (InsufficientFundsException)
            {
                Console.WriteLine("Insuficent");
            }
            catch (LimitExceededException)
            {
                Console.WriteLine("Limit");
            }
            catch (PaymentServiceException)
            {
                Console.WriteLine("Payment");
            }
        }
    }
}
