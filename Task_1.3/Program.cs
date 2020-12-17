using System;
using Library;

namespace Task_1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Account[] accounts = new Account[1000000];
            for (int i = 0; i < accounts.Length; i++)
            {
                accounts[i] = new Account("UAH");
            }

            accounts = Work.GetSortedAccounts(accounts);
            Console.Write("Enter id->");
            int id = int.Parse(Console.ReadLine());
            int iteration;
            int index = Work.GetAccount(id, ref accounts,out iteration);

            if(index == -1)
            {
                Console.WriteLine("Not found");
            }
            else
            {
                Console.WriteLine($"Index = {index}, iteration = {iteration}");
            }

            Console.WriteLine();
        }
    }
}
