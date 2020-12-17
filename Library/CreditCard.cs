using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Library
{
    public class CreditCard : PaymentMethodBase, ISupportDeposit, ISupportWithdrawal
    {
        public CreditCard()
        {
            Name = "CreditCard";
            OneTImeLimit = 3000;

        }

        public void StartDeposit(decimal amount, string currency)
        {
            string console="";
            decimal cardNum;
            while (console.Replace(" ","").Length!=16&&!decimal.TryParse(console,out cardNum))
            {
                Console.Write("Enter number of card (16 numbers, starts with 4 or 5)->");
                console = Console.ReadLine();
                if (!(console.StartsWith("4") | console.StartsWith("5")))
                {
                    console = "";
                    Console.WriteLine("Please, enter correct number of card");
                    continue;
                }
                else if (console.Replace(" ","").Length != 16)
                {
                    Console.WriteLine("Count of numbers should be 16");
                }
            }
            console = "";
            string pattern = (@"[0-9]{2}/[0-9]{2}");
            while (console.Trim().Length != 5)
            {
                Console.Write("Enter expire date (format 'mm/yy') ->");
                console = Console.ReadLine();

                if (!Regex.IsMatch(console, pattern))
                {
                    Console.WriteLine("Enter correct date in format mm/yy");
                    console = "";
                    continue;
                }

                else 
                {
                    string[] split = console.Split("/");
                    int mm = Convert.ToInt32(split[0]);
                    int yy = 2000+Convert.ToInt32(split[1]);
                    if (mm<0 || mm > 12)
                    {
                        Console.WriteLine("Invalid input");
                        console = "";
                        continue;
                    }
                    else if(yy < DateTime.Now.Year)
                    {
                        Console.WriteLine("Your card has expired");
                        console = "";
                        continue;
                    }
                    else if(yy == DateTime.Now.Year)
                    { 
                        if(DateTime.Now.Month < mm)
                        {
                            Console.WriteLine("Your card has expired");
                            console = "";
                            continue;
                        }
                    }

                }
            }
            string expireDate = console;
            console = "";
            int cvv;
            while (console.Length != 3)
            {
                Console.Write("Enter the cvv->");
                console = Console.ReadLine();
                if(!int.TryParse(console,out cvv))
                {
                    Console.WriteLine("Invalid input");
                    console = "";
                    continue;
                }
            }
            Console.WriteLine($"Your deposit {amount} {currency} from your card successfully. Press any key to continue...");
            Console.ReadKey();
        }

        public void StartWithdrawal(decimal amount, string currency)
        {
            string console = "";
            decimal cardNum;
            while (console.Replace(" ","").Length != 16 && !decimal.TryParse(console, out cardNum))
            {
                Console.Write("Enter number of card (16 numbers, starts with 4 or 5)->");
                console = Console.ReadLine();
                if (!(console.StartsWith("4") | console.StartsWith("5")))
                {
                    console = "";
                    Console.WriteLine("Please, enter correct number of card");
                    continue;
                }
                else if (console.Replace(" ", "").Length != 16)
                {
                    Console.WriteLine("Count of numbers should be 16");
                }
            }
        }
    }
}
