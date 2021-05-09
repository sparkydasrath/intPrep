using System;
using System.Collections.Generic;
using System.Text.Json;

namespace lc_2021_01
{
    public static class LcMediumRunner
    {
        public static void RunLetterCombinations()
        {
            LcMedium med = new LcMedium();
            IList<string> results = med.LetterCombinations("23");
            Console.WriteLine(JsonSerializer.Serialize(results));
        }

        public static void RunCombine()
        {
            Console.WriteLine(JsonSerializer.Serialize(LcMedium.Combine(4, 2)));
        }
    }
}