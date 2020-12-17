using System;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Player player = new Player("Vasya", "Gritsin", "vasya@gmail.com", "123", "EUR");
                player.Deposit(100, "UAH");
                player.Withdraw(2, "USD");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Try again bro");
            }
            catch
            {
                throw;
            }

            

            Console.ReadLine();
        }
    }
}
