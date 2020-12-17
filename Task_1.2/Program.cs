using System;
using System.Linq;
using Library;

namespace Task_1._2
{
    class Program
    {
        static void Main(string[] args)
        {

            Account[] accounts = new Account[1000000];
            for(int i = 0; i< accounts.Length; i++)
            {
                accounts[i] = new Account("UAH");
            }

            accounts = Work.GetSortedAccounts(accounts);

            Console.WriteLine("First 10 accounts are:");
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(accounts[i].Id);
            }

            Console.WriteLine("Last 10 accounts are:");
            for (int i = accounts.Length-10; i < accounts.Length; i++)
            {
                Console.WriteLine(accounts[i].Id);
            }

            Console.ReadLine();

        }
        //static Account[] GetSortedAccounts(Account[] accounts)
        //{
        //        Account temp;
        //        for (int i = 0; i < accounts.Length - 1; i++)
        //        {
        //            for (int j = i + 1; j < accounts.Length; j++)
        //            {
        //                if (accounts[i].Id > accounts[j].Id)
        //                {
        //                    temp = accounts[i];
        //                    accounts[i] = accounts[j];
        //                    accounts[j] = temp;
        //                }
        //            }
        //        }
        //        return accounts;
        //}
        //static Account[] GetSortedAccountsFast(Account[] accounts)
        //{
        //    return accounts.OrderBy(x => x.Id).ToArray();
        //}
    }
}
