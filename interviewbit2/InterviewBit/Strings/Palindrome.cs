using System.Runtime.Remoting.Messaging;

namespace Strings
{
    public class Palindrome
    {
        public bool IsPalindrome(string s)
        {
            if (s.Length < 2) return true;

            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                if (s[left] != s[right]) return false;
                left++;
                right--;
            }

            return true;
        }
    }
}