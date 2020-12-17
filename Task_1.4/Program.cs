using System;
using Library;

namespace Task_1._4
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

            Work.QuickSort(accounts);

            Console.WriteLine("First 10 accounts are:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(accounts[i].Id);
            }

            Console.WriteLine("Last 10 accounts are:");
            for (int i = accounts.Length - 10; i < accounts.Length; i++)
            {
                Console.WriteLine(accounts[i].Id);
            }
        }
    }
}
