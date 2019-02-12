using System;

namespace Strings
{
    public class CheckPermutation
    {
        public bool IsPermutation(string one, string two)
        {
            // approach 1, sort strings and compare
            if (one.Length != two.Length) return false;

            char[] oneS = one.ToCharArray();
            char[] twoS = two.ToCharArray();

            Array.Sort(oneS);
            Array.Sort(twoS);

            for (int i = 0; i < one.Length; i++)
            {
                if (oneS[i] != twoS[i]) return false;
            }

            return true;
        }
    }
}