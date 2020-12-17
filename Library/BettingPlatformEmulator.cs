using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Library
{
    public class BettingPlatformEmulator
    {
        List<Player> Players  { get; set; }
        Player ActivePlayer { get; set; }
        Account Account { get; set; }
        BetService BetService { get; set; }
        PaymentService PaymentService { get; set; }
        Random rnd;

        public BettingPlatformEmulator()
        {
            Account = new Account("USD");
            Players = new List<Player>();
            BetService = new BetService();
            PaymentService = new PaymentService();
            rnd = new Random();
        }

        public void Start()
        {
            bool isGoing = true;
            while (isGoing)
            {
                if (ActivePlayer == null)
                {
                    Console.Clear();
                    Console.WriteLine("1. Register\n2. Login\n3. Stop");
                    var key = Console.ReadKey().Key;
                    switch (key)
                    {
                        case ConsoleKey.NumPad1:
                        case ConsoleKey.D1:
                            Register();
                            break;

                        case ConsoleKey.NumPad2:
                        case ConsoleKey.D2:
                            Console.Clear();
                            Player player1;
                            ActivePlayer = Login();
                            break;
                        case ConsoleKey.NumPad3:
                        case ConsoleKey.D3:
                            Stop(ref isGoing);
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("1. Deposit\n2. Withdraw\n3. GetOdd\n4. Bet\n5. Logout");
                    var key = Console.ReadKey().Key;
                    switch (key)
                    {
                        case ConsoleKey.NumPad1:
                        case ConsoleKey.D1:
                        
                            Console.Clear();
                            Deposit();
                            break;

                        case ConsoleKey.NumPad2:
                        case ConsoleKey.D2:
                            Withdraw();
                            break;

                        case ConsoleKey.NumPad3:
                        case ConsoleKey.D3:
                            Console.Clear();
                            var odd = BetService.GetOdds();
                            Console.WriteLine($"Odd is {odd}. Press any key to continue...");
                            Console.ReadKey();
                            break;

                        case ConsoleKey.NumPad4:
                        case ConsoleKey.D4:
                            decimal bet=0;
                            string console;
                            Console.Clear();
                            Console.WriteLine("If you don't want to place enter 'cancel' on bet field");
                            Console.WriteLine($"Avaliable on your account {ActivePlayer.Account.Amount} {ActivePlayer.Account.Currency}");
                            do
                            {
                                Console.Write("Enter your bet->");
                                console = Console.ReadLine();
                                if (console == "cancel")
                                {
                                    goto default;
                                }
                            }
                            while (!decimal.TryParse(console, out bet));
                            bet = Math.Round(bet, 2);
                            if (bet > ActivePlayer.Account.Amount)
                            {
                                Console.WriteLine("Not enough money on your account. Press any key to continue...");
                                Console.ReadKey();
                                goto case ConsoleKey.NumPad4;
                            }
                            if (bet <=0)
                            {
                                Console.WriteLine("Invalid bet. Press any key to continue...");
                                Console.ReadKey();
                                goto case ConsoleKey.NumPad4;
                            }

                            ActivePlayer.Account.Amount -= bet;
                            var win = BetService.Bet(bet);
                            ActivePlayer.Account.Amount += win;
                            Console.WriteLine($"You won {win}{ActivePlayer.Account.Currency}");
                            Console.ReadLine();
                            goto case ConsoleKey.NumPad4;

                        case ConsoleKey.NumPad5:
                        case ConsoleKey.D5:
                            Logout();
                            break;

                        default:
                            break;
                    }
               
                }
            }
        }
        void Stop(ref bool isGoing)
        {
            Console.Clear();
            isGoing = false;
        }
        void Register()
        {
            Console.Clear();
            Console.Write("Enter First Name->");
            string fName = Console.ReadLine();
            Console.Write("Enter Last Name->");
            string lName = Console.ReadLine();
            Console.Write("Enter Email->");
            string email = Console.ReadLine();
            Console.Write("Enter password->");
            string password = Console.ReadLine();
            string currency;
            Console.WriteLine("Avaliable currencies: USD, EUR, UAH");
            do
            {
                Console.Write("Enter currency->");
                currency = Console.ReadLine();
            }
            while (currency != "EUR" & currency != "USD" & currency != "UAH");
            Player player = new Player(fName, lName, email, password, currency);
            ActivePlayer = player;
            Players.Add(player);
        }
        Player Login()
        {
            Console.Write("Enter Email->");
            string email = Console.ReadLine();
            Console.Write("Enter password->");
            string password = Console.ReadLine();
            var player = Players.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            return player;
        }
        void Logout()
        {
            ActivePlayer = null;
        }
        void Deposit()
        {
            Console.Clear();
            string currency;
            double amount;

            do
            {
                Console.Write("Enter currency->");
                currency = Console.ReadLine();
            }
            while (currency != "USD" && currency != "EUR" && currency !="UAH");

            do
            {
                Console.Write("Enter amount->");
            }
            while (!double.TryParse(Console.ReadLine(), out amount));
            
            try
            {
                PaymentService.Account = ActivePlayer.Account;
                PaymentService.StartDeposit(Convert.ToDecimal(amount), currency);
                ActivePlayer.Deposit(Math.Round(Convert.ToDecimal(amount), 2), currency);
                Account.Deposit(Math.Round(Convert.ToDecimal(amount), 2), currency);
                PaymentService.SubmitTransaction();
            }
            catch (InsufficientFundsException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            catch (LimitExceededException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            catch (PaymentServiceException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }

        }

        void Withdraw()
        {

            Console.Clear();
            string currency;
            double amount;

            do
            {
                Console.Write("Enter currency->");
                currency = Console.ReadLine();
            }
            while (currency != "USD" && currency != "EUR" && currency != "UAH");

            do
            {
                Console.Write("Enter amount->");
            }
            while (!double.TryParse(Console.ReadLine(), out amount));

            try
            {
                //throw exceptions
                if (amount > 0)
                {
                    if (Convert.ToDecimal(amount) > ActivePlayer.Account.Amount)
                        throw new InsufficientFundsException("Please, try to make a transaction with lower amount or change the payment method. Press any key to continue...");
                    
                    else if (Convert.ToDecimal(amount) > Account.Amount)
                        throw new InsufficientFundsException("There is some problem on the platform side. Please try it later. Press any key to continue...");
                    
                    else
                    {
                        PaymentService.Account = ActivePlayer.Account;
                        PaymentService.StartWithdrawal(Math.Round(Convert.ToDecimal(amount), 2), currency);
                        ActivePlayer.Withdraw(Math.Round(Convert.ToDecimal(amount), 2), currency);
                        Account.Withdraw(Math.Round(Convert.ToDecimal(amount), 2), currency);
                        PaymentService.SubmitTransaction();
                        Console.WriteLine($"Operation success. Your amount is {ActivePlayer.Account.Amount}. Press any key to continue...");
                        Console.ReadKey();
                    }
                }
            }
            catch(InsufficientFundsException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            catch (LimitExceededException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            catch (PaymentServiceException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }

        }
    }
}
