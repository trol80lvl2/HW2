using System;
using Library;

namespace Task_4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentService paymentService = new PaymentService();
            try
            {
                paymentService.StartDeposit(1000, "USD");
            }
            catch(LimitExceededException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(NullReferenceException)
            {
                Console.WriteLine("Account isn't initialized");
            }
            

        }
    }
}
