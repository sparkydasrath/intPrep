using System.Collections.Generic;

namespace InterviewTests.Blackstone
{
    /// <summary>
    /// Abstract out the definition and implementation of the denominations from its use
    /// </summary>
    public struct Denominations
    {
        public Dictionary<decimal, string> DefaultDenominations => GetDefaultDenominations();

        public void Add(decimal key, string value)
        {
            if (!DefaultDenominations.ContainsKey(key))
                DefaultDenominations[key] = value;
        }

        public void Remove(decimal key)
        {
            if (!DefaultDenominations.ContainsKey(key)) return;
            DefaultDenominations.Remove(key);
        }

        private static Dictionary<decimal, string> GetDefaultDenominations()
        {
            Dictionary<decimal, string> defaultDenominationMap = new Dictionary<decimal, string>()
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
            return defaultDenominationMap;
        }
    }
}