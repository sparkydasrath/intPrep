using System;
using System.Collections.Generic;

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

            Dictionary<double, string> denominationMap = GetDenominations();

            double transaction = priceCashPair.CashGiven - priceCashPair.PurchasePrice;

            if (Math.Abs(transaction) < 0.001) return denominationMap[transaction];

            return null;
        }

        private Dictionary<double, string> GetDenominations()
        {
            Dictionary<double, string> denominationMap = new Dictionary<double, string>(12)
            {
                [0.00d] = "ZERO",
                [0.01d] = "PENNY",
                [0.05d] = "NICKEL",
                [0.10d] = "DIME",
                [0.25d] = "QUARTER",
                [0.50d] = "HALF DOLLAR",
                [1.00d] = "ONE",
                [2.00d] = "TWO",
                [5.00d] = "FIVE",
                [10.00d] = "TEN",
                [20.00d] = "TWENTY",
                [100.00d] = "ONE HUNDRED",
            };

            return denominationMap;
        }

        private PriceCashPair ParseInput(string input)
        {
            var split = input.Split(';');
            return new PriceCashPair
            {
                PurchasePrice = Convert.ToDouble(split[0]),
                CashGiven = Convert.ToDouble(split[1])
            };
        }

        private struct PriceCashPair
        {
            public double CashGiven { get; set; }
            public double PurchasePrice { get; set; }
        }
    }
}