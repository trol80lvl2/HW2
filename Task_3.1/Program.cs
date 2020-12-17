﻿using System;
using Library;

namespace Task_3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            CreditCard creditCard = new CreditCard();
            Privet48 privet48 = new Privet48();
            Stereobank stereobank = new Stereobank();
            GiftVoucher giftVoucher = new GiftVoucher();
            creditCard.StartDeposit(50, "USD");
            creditCard.StartWithdrawal(50,"USD");
            privet48.StartDeposit(50,"USD");
            stereobank.StartWithdrawal(50,"USD");
            try
            {
                giftVoucher.StartDeposit(50, "USD");
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            giftVoucher.StartDeposit(500, "USD");

        }
    }
}
