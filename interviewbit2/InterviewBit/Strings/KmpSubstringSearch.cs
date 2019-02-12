namespace Strings
{
    public class KmpSubstringSearch
    {
        /*
         *https://www.youtube.com/watch?v=GTJr8OvyEVQ&index=5&list=PLrmLmBdmIlpvxhscYQdvfFNWU_pdkG5de&t=0s
         */

        public int[] BuildPrefixToSuffixMatchingArray(string substring)
        {
            int[] truthArray = new int[substring.Length];

            int i = 1, j = 0;

            while (i < substring.Length)
            {
                if (substring[i] == substring[j])
                {
                    truthArray[i] = j + 1;
                    i++;
                    j++;
                }
                else
                {
                    if (j != 0) j = truthArray[j - 1];
                    else
                    {
                        truthArray[i] = 0;
                        i++;
                    }
                }
            }
            return truthArray;
        }

        public bool KmpSearch(string given, string substring)
        {
            if (string.IsNullOrWhiteSpace(given) && string.IsNullOrWhiteSpace(substring)) return true;

            if (string.IsNullOrWhiteSpace(given) && !string.IsNullOrWhiteSpace(substring) &&
                substring.Length > 0) return false; // can't compare a non-empty substring to a null

            if (given?.Length == 0 && substring?.Length == 0) return true;

            if (substring?.Length > given?.Length) return false;

            int[] truthArray = BuildPrefixToSuffixMatchingArray(substring);

            if (given == null || substring == null) return false;

            int i = 0, j = 0;

            while (i < given.Length && j < substring.Length)
            {
                if (given[i] == substring[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    if (j != 0) j = truthArray[j - 1];
                    else i++;
                }
            }

            return j == substring.Length;
        }
    }
}