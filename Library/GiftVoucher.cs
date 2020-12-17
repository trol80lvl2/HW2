using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class GiftVoucher : PaymentMethodBase, ISupportDeposit
    {
        List<long> voucherCodes;
        public GiftVoucher()
        {
            Name = "GiftVoucher";
            voucherCodes = new List<long>();
        }
        public void StartDeposit(decimal amount, string currency)
        {
            if (amount == 100 || amount == 500 || amount == 1000)
            {
                string console = "";
                long code=0;
                while (console.Length != 10 && !long.TryParse(console, out code))
                {
                    Console.Write("Enter code of your voucher->");
                    console = Console.ReadLine();
                    if (console.Length != 10)
                    {
                        Console.WriteLine("Length of code should be 10 numbers");
                        console = "";
                        continue;
                    }
                    else
                    {
                        if (!long.TryParse(console, out code))
                        {
                            Console.WriteLine("Please, use only digits");
                            console = "";
                            continue;
                        }
                    }

                }
                if (voucherCodes.Contains(code))
                    throw new LimitExceededException("the code is no longer valid");
                voucherCodes.Add(code);
                Console.WriteLine($"Your {amount} {currency} voucher used successfully. Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                throw new InvalidOperationException("Invalid summ");
            }
        }
    }
}
