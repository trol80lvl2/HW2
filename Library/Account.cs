using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Account
    {
        public Dictionary<string, decimal> Currencies { get; } = new Dictionary<string, decimal>
        {
            { "USD/UAH", 28.33m },
            { "UAH/USD", 0.0353m },
            { "EUR/UAH", 33.63m },
            { "UAH/EUR", 0.02974m },
            { "EUR/USD", 1.19m },
            { "USD/EUR", 0.84m },
            { "UAH/UAH", 1m },
            { "EUR/EUR", 1m },
            { "USD/USD", 1m }
        };

        public int Id { get; private set; }
        public string Currency { get; private set;}
        public decimal Amount { get;  set; }

        public Account(string currency)
        {
            if (currency != "UAH" && currency != "USD" && currency != "EUR")
                throw new NotSupportedException($"Currency '{currency}' isn't supported'");
            else
            {
                Random rnd = new Random();
                Id = rnd.Next(100000, 99999999);
                Amount = 0;
                Currency = currency;
            }
        }

        //Try hashmaps here
        public void Deposit(decimal amount, string currency)
        {
            if (currency != "UAH" && currency != "USD" && currency != "EUR")
                throw new NotSupportedException($"Currency '{currency}' isn't supported'");
            Amount += (currency == Currency) ? amount : Math.Round(amount * Currencies[currency+"/"+Currency],2);
        }

        public void Withdraw(decimal amount, string currency)
        {
            if (currency != "UAH" && currency != "USD" && currency != "EUR")
                throw new NotSupportedException($"Currency '{currency}' isn't supported'");
            if (currency == Currency)
                Amount = (amount <= Amount) ? Amount - amount : throw new InvalidOperationException("There is some problem on the platform side. Please try it later");
            else
                Amount = (amount * Math.Round(Currencies[currency + "/" + Currency], 2) <= Amount) ? Amount - (amount* Math.Round(Currencies[currency + "/" + Currency], 2)) : throw new InvalidOperationException();
        }
    }
}
