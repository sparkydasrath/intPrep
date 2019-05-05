using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace InterviewTests.Blackstone
{
    public class CashRegister
    {
        private const string Error = "ERROR";
        private const string Zero = "ZERO";

        public string GetChange(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return Error;

            PriceCashPair priceCashPair = ParseInput(input);

            if (priceCashPair.CashGiven < priceCashPair.PurchasePrice) return Error;

            Dictionary<decimal, string> denominationMap = GetDenominations();

            decimal transaction = Math.Round(priceCashPair.CashGiven - priceCashPair.PurchasePrice, 2, MidpointRounding.AwayFromZero);

            if (transaction == 0) return Zero;// denominationMap[transaction];

            var keys = denominationMap.Keys.ToList();
            List<string> results = new List<string>();

            for (int i = keys.Count - 1; i >= 0; i--)
            {
                // work backwards trying to use each denomination
                decimal div = transaction / keys[i];
                decimal rem = transaction % keys[i];

                // if you can't use the denomination, just continue
                // ex: you have a change of $5 but when you do $5/100, you get zero, so you know you
                // can't give $100 back in change

                if (IsDivisionEqualToZero(div)) continue;

                // otherwise, if we can use this denomination, the value of div will tell you how%
                // many times you can use it
                // ex: if transaction = $13 then we do 16/10 = 1, so you have at least one TEN in the result
                // now the rest of the transaction to process = 16 % 10 ==> 6

                // append the result to the sb and update the div
                for (int j = 0; j < Math.Floor(div); j++)
                {
                    // get the denomination
                    decimal denomination = keys[i];
                    transaction -= denomination;
                    results.Add(denominationMap[denomination]);
                }
            }

            return string.Join(",", results);
        }

        private Dictionary<decimal, string> GetDenominations()
        {
            Dictionary<decimal, string> denominationMap = new Dictionary<decimal, string>(11)
            {
                [0.01m] = "PENNY",
                [0.05m] = "NICKEL",
                [0.10m] = "DIME",
                [0.25m] = "QUARTER",
                [0.50m] = "HALF DOLLAR",
                [1.00m] = "ONE",
                [2.00m] = "TWO",
                [5.00m] = "FIVE",
                [10.00m] = "TEN",
                [20.00m] = "TWENTY",
                [100.00m] = "ONE HUNDRED",
            };
            return denominationMap;
        }

        private bool IsDivisionEqualToZero(decimal division)
        {
            string[] divAsString = division.ToString(CultureInfo.InvariantCulture).Split('.');
            return Convert.ToInt32(divAsString[0]) == 0;
        }

        private PriceCashPair ParseInput(string input)
        {
            var split = input.Split(';');
            return new PriceCashPair
            {
                PurchasePrice = Convert.ToDecimal(split[0]),
                CashGiven = Convert.ToDecimal(split[1])
            };
        }

        private struct PriceCashPair
        {
            public decimal CashGiven { get; set; }
            public decimal PurchasePrice { get; set; }
        }
    }
}