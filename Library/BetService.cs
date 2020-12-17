using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class BetService
    {
        private decimal odd { get; set; }
        Random rnd = new Random();

        public BetService()
        {
         
            odd = Math.Round(Convert.ToDecimal(rnd.NextDouble() * (25.00 - 1.01) + 1.01),2);
        }

        public float GetOdds()
        {
            odd = Math.Round(Convert.ToDecimal(rnd.NextDouble() * (25.00 - 1.01) + 1.01), 2);
            return (float)odd;
        }

        public decimal Bet(decimal amount)
        {
            return (IsWon()) ? amount * odd : 0;
        }

        private bool IsWon()
        {
            return (GetChance()>=rnd.Next(0,101))? true: false;
        }

        private int GetChance()
        {
            decimal coef =  (99m - 4m) / (25m-1m);

            return (int)Math.Round((99-((odd-1)*coef)));
        }
    }
}
