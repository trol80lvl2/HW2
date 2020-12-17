using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Player
    {
        public int Id { get; private set; }
        private string FirstName { get; }
        private string LastName { get; }
        public string Email { get; private set; }
        public  string Password { get; private set; }
        public Account Account { get; set; }
        public decimal DailyLimitP48 { get; set; }
        public decimal DailyLimitMB { get; set; }

        public Player(string firstName, string lastName, string email, string password,string currency)
        {
            try
            {
                Random rnd = new Random();
                Id = rnd.Next(100000, 999999);
                FirstName = firstName;
                LastName = lastName;
                Email = email;
                Password = password;
                Account = new Account(currency);
            }
            catch(NotSupportedException e)
            {
                throw;
            }
            catch
            {
                throw;
            }
        }

        public bool IsPasswordValid(string password)
        {
            return Password == password;
        }

        public void Deposit(decimal amount, string currency)
        {
            Account.Deposit(amount, currency);
        }

        public void Withdraw(decimal amount, string currency)
        {
            try
            {
                Account.Withdraw(amount, currency);
            }
            catch(InvalidOperationException)
            {
                throw new InvalidOperationException("There is insufficient funds on your account");
            }
            catch
            {
                throw;
            }
        }
    }
}
