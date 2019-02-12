namespace General
{
    public class RecursionIsPalindrome
    {
        public static bool IsPalindrome(string s)
        {
            if (s.Length < 2)
            {
                return true;
            }

            char first = s[0];
            char last = s[s.Length - 1];
            if (first == last)
            {
                string rest = s.Substring(1, s.Length - 1 - 1);
                return IsPalindrome(rest);
            }

            return false;
        }
    }
}