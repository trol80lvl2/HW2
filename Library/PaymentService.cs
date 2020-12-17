using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class PaymentService:ISupportDeposit,ISupportWithdrawal
    {
        PaymentMethodBase[] AvailablePaymentMethod;
        ISupportDeposit[] SupportDeposits;
        ISupportWithdrawal[] SupportWithdrawals;

        Random rnd = new Random();

        public Account Account { get; set; }
        private Transaction currentTransaction;
        private IList<Transaction> successfulTransactions = new List<Transaction>();

        public PaymentService()
        {
            AvailablePaymentMethod = new PaymentMethodBase[] { new CreditCard(), new Privet48(), new Stereobank(), new GiftVoucher()};
            SupportDeposits = new ISupportDeposit[] { new CreditCard(), new Privet48(), new Stereobank(), new GiftVoucher() };
            SupportWithdrawals = new ISupportWithdrawal[] { new CreditCard(), new Privet48(), new Stereobank() };
        }

        public void StartDeposit(decimal amount, string currency)
        {
            if (rnd.Next(1, 101) <= 2)
                throw new PaymentServiceException("Something went wrong. Try again later. Press any key to continue...");
            while (true)
            {
                for(int i = 0; i < AvailablePaymentMethod.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {AvailablePaymentMethod[i].Name}");
                }
                Console.Write("->");
                string key = Console.ReadLine();
                try
                {
                    int i = int.Parse(key) - 1;
                    decimal convertedAmount = amount * Account.Currencies[currency + "/UAH"];
                    checkAmountLimit(AvailablePaymentMethod[i], convertedAmount);
                    SupportDeposits[i].StartDeposit(amount, currency);
                    currentTransaction = new Transaction { AccountId = Account.Id, BankName = AvailablePaymentMethod[i].Name, Amount = convertedAmount };
                    break;
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    break;
                }
                catch
                {
                    throw;
                }
            }
        }

        public void StartWithdrawal(decimal amount, string currency)
        {
            if (rnd.Next(1, 101) <= 2)
                throw new PaymentServiceException("Something went wrong. Try again later. Press any key to continue...");
            while (true)
            {
                for (int i = 0; i < SupportWithdrawals.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {AvailablePaymentMethod[i].Name}");
                }
                Console.Write("->");
                string key = Console.ReadLine();
                try
                {
                    int i = int.Parse(key) - 1;
                    decimal convertedAmount = amount * Account.Currencies[currency + "/UAH"];
                    checkAmountLimit(AvailablePaymentMethod[i], convertedAmount);
                    SupportWithdrawals[i].StartWithdrawal(amount, currency);
                    currentTransaction = new Transaction { AccountId = Account.Id, BankName = AvailablePaymentMethod[i].Name, Amount =  convertedAmount};
                    break;
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    break;
                }
                catch
                {
                    Console.WriteLine("Please, select correct payment method");
                    continue;
                }
            }
        }

        public void SubmitTransaction() => successfulTransactions.Add(currentTransaction);

        private void checkAmountLimit(PaymentMethodBase currentPaymentMethod, decimal amount)
        {
            var accountBankTransactions = successfulTransactions.Where(x => x.BankName == currentPaymentMethod.Name && x.AccountId == Account.Id);
            decimal sum = amount + accountBankTransactions.Sum(x => x.Amount);

            if (amount > currentPaymentMethod.OneTImeLimit)
                throw new LimitExceededException($"Please, try to make a transaction with lower amount, maximal once operation {currentPaymentMethod.OneTImeLimit} UAH. Press any key to continue...");
            if (sum > currentPaymentMethod.AmountLimit)
                throw new LimitExceededException("Please, try to make a transaction with lower amount");
        }
    }
}
