using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public abstract class Bank : PaymentMethodBase, ISupportDeposit, ISupportWithdrawal
    {
        public string[] AvailableCards { get; set; }

        public virtual void StartDeposit(decimal amount, string currency)
        {
            Console.WriteLine($"Welcome, dear client, to the online bank {Name}");
            Console.Write($"Please, enter your login->");
            string login = Console.ReadLine();
            Console.Write("Please, enter your password->");
            Console.ReadLine();
            Console.WriteLine($"Hello Mr {login}. Pick a card to proceed the transaction");
            for(int i = 0; i < AvailableCards.Length; i++)
            {
                Console.WriteLine($"{i+1}. {AvailableCards[i]}");
            }
            int number;
            do
            {
                Console.Write("Enter number of card->");
            }
            while (!int.TryParse(Console.ReadLine(),out number)&&number<=AvailableCards.Length&&number>0);

            Console.WriteLine($"You’ve withdraw {amount} {currency} from your {AvailableCards[--number]} card successfully. Press any key to continue...");
            Console.ReadKey();
        }

        public void StartWithdrawal(decimal amount, string currency)
        {
            Console.WriteLine($"Welcome, dear client, to the online bank {Name}");
            Console.Write($"Please, enter your login->");
            string login = Console.ReadLine();
            Console.Write("Please, enter your password->");
            Console.ReadLine();
            Console.WriteLine($"Hello Mr {login}. Pick a card to proceed the transaction");
            for (int i = 0; i < AvailableCards.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {AvailableCards[i]}");
            }
            int number;
            do
            {
                Console.Write("Enter number of card->");
            }
            while (!int.TryParse(Console.ReadLine(), out number) && number <= AvailableCards.Length && number > 0);
        }
    }
}
