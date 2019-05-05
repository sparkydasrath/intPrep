using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTests.Blackstone
{
    public class Question3
    {
        /*
            Programming Challenge Description:
            The goal of this challenge is to design a cash register program. You will be given two decimal numbers.
            The first is the purchase price (PP) of the item. The second is the cash (CH) given by the customer. Your register currently has the following bills/coins within it:
                'PENNY': .01,
                'NICKEL': .05,
                'DIME': .10,
                'QUARTER': .25,
                'HALF DOLLAR': .50,
                'ONE': 1.00,
                'TWO': 2.00,
                'FIVE': 5.00,
                'TEN': 10.00,
                'TWENTY': 20.00,
                'FIFTY': 50.00,
                'ONE HUNDRED': 100.00
            The aim of the program is to calculate the change that has to be returned to the customer.
            Input:
            Your program should read lines of text from standard input. Each line contains two numbers which are separated by a semicolon.
            The first is the Purchase price (PP) and the second is the cash(CH) given by the customer.
            Output:
            For each line of input print a single line to standard output which is the change to be returned to the customer.
            In case the CH < PP, print out ERROR. If CH == PP, print out ZERO. For all other cases print the amount that needs to be returned,
            in terms of the currency values provided. The output should be alphabetically sorted.
         */

        private const string Error = "ERROR";
        private const string Zero = "ZERO";

        public string GetChange(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return Error;

            PriceCashPair priceCashPair = ParseInput(input);

            if (priceCashPair.CashGiven < priceCashPair.PurchasePrice) return Error;

            Dictionary<decimal, string> denominationMap = new Denominations().DefaultDenominations;

            decimal transaction = priceCashPair.CashGiven - priceCashPair.PurchasePrice;

            if (transaction == 0) return Zero;// denominationMap[transaction];

            var keys = denominationMap.Keys.ToList();
            List<string> results = new List<string>();

            for (int i = keys.Count - 1; i >= 0; i--)
            {
                // work backwards trying to use each denomination
                decimal div = transaction / keys[i];

                // if you can't use the denomination, just continue
                // ex: you have a change of $5 but when you do $5/100, you get zero, so you know you
                // can't give $100 back in change

                // grab the whole number part of the division to do zero checking this will avoid all
                // the fractional checks
                if ((int)div == 0) continue;

                // otherwise, if we can use this denomination, the value of div will tell you how
                // many times you can use it
                // ex: if transaction = $13 then we do 16/10 = 1, so you have at least one TEN in the result
                // now the rest of the transaction to process = 16 % 10 ==> 6

                // append the result to the results and update the div
                for (int j = 0; j < Math.Floor(div); j++)
                {
                    // get the denomination
                    decimal denomination = keys[i];
                    // subtract out each block of change that can be given back in this denomination
                    transaction -= denomination;
                    results.Add(denominationMap[denomination]);
                }
            }

            return string.Join(",", results);
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
            // simple structure make the code more contextual and readable
            public decimal CashGiven { get; set; }

            public decimal PurchasePrice { get; set; }
        }
    }
}