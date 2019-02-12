namespace Strings
{
    public class EditDistance
    {
        public bool IsOneEditDistance(string s, string t)
        {
            // https://leetcode.com/problems/one-edit-distance/discuss/50170/2ms-Java-solution-with-explanation

            // this removes difference between character insertion and removal
            if (s.Length > t.Length) return IsOneEditDistance(t, s);

            // If difference in lengths is greater than 1, it cannot be IsOneEditDistance
            if (t.Length - s.Length > 1) return false;

            int i = 0;
            while (i < s.Length)
            {
                if (s[i] != t[i])
                {
                    // If the length is different rest of string s including this character should
                    // match since unmatched character in string t would account for one edit
                    // (i.e.deletion) distance. If on the other hand if length is same, current
                    // character in string s would account for one edit (i.e. substitution distance,
                    // and hence rest of the string needs to be matched.
                    return s.Substring(i + 1) == t.Substring(i + 1) || s.Substring(i) == t.Substring(i + 1);
                }
                i++;
            }

            // code reaching here implies, prefixes of two strings are same. Now if length is equal
            // it would imply zero edit distance and hence should return false.
            return s.Length + 1 == t.Length;
        }
    }
}