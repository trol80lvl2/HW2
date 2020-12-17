using System;
using Library;

namespace Task_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            BetService betService = new Library.BetService();
            float odd=0;
            for(int i = 0; i < 10; i++)
            {
                odd = betService.GetOdds();
            }
            Console.WriteLine($"I bet 100 USD with odd {odd} and earned {betService.Bet(100)}");
            BetWhileWinLose();


        }

        //i looked for at least some balance
        static void BetWhileWinLose()
        {
            decimal amount = 10000;
            BetService betService = new BetService();

            while(amount>0 && amount < 150000)
            {
                float odd = betService.GetOdds();
                if (odd>21 && odd < 25)
                {
                    amount -= 2000;
                    amount += betService.Bet(2000);
                    Console.WriteLine(amount);
                }
                else
                {
                    continue;
                }
            }
            Console.WriteLine($"Game over. My balance is {amount}");
        }
    }
}
