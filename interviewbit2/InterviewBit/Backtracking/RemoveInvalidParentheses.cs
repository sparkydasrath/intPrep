using System.Collections.Generic;

namespace Backtracking
{
    public class RemoveInvalidParentheses
    {
        /*
         301. Remove Invalid Parentheses https://leetcode.com/problems/remove-invalid-parentheses/
        Hard

        Remove the minimum number of invalid parentheses in order to make the input string valid. Return all possible results.

        Note: The input string may contain letters other than the parentheses ( and ).

        Example 1:

        Input: "()())()"
        Output: ["()()()", "(())()"]

        Example 2:

        Input: "(a)())()"
        Output: ["(a)()()", "(a())()"]

        Example 3:

        Input: ")("
        Output: [""]

         */

        public List<string> RemoveInvalidParenthesesBfs(string s)
        {
            /*
             In BFS we handle the states level by level, in the worst case, we need to handle all the levels, we can analyze the time complexity level by level and add them up to get the final complexity.

            On the first level, there's only one string which is the input string s,
            let's say the length of it is n, to check whether it's valid, we need O(n) time.
            On the second level, we remove one ( or ) from the first level, so there are C(n, n-1)
            new strings, each of them has n-1 characters, and for each string,
            we need to check whether it's valid or not, thus the total time complexity
            on this level is (n-1) x C(n, n-1). Come to the third level,
            total time complexity is (n-2) x C(n, n-2), so on and so forth...
            Finally we have this formula:

            T(n) = n x C(n, n) + (n-1) x C(n, n-1) + ... + 1 x C(n, 1) = n * 2^(n-1)
             */

            List<string> results = new List<string>();
            if (s == null) return results;

            // BFS Solution https://leetcode.com/problems/remove-invalid-parentheses/discuss/75032/Share-my-Java-BFS-solution
            HashSet<string> visited = new HashSet<string>();
            Queue<string> q = new Queue<string>();

            q.Enqueue(s);
            visited.Add(s);
            bool found = false;
            while (q.Count != 0 && !found)
            {
                // the idea is to remove each parenthesis, generate a new string, and enqueue that
                for (int i = 0; i < s.Length; i++)
                {
                    // dequeue the item
                    string seedStr = q.Dequeue();

                    // check if it is valid and add it ot the result set
                    if (IsValid(seedStr))
                    {
                        results.Add(seedStr);
                        found = true;
                    }

                    if (!found)
                    {
                        /*
                         otherwise, we should iterate the string
                         the first open or close we see, remove it
                         if the new string is not visited yet, add it to the queue
                         */
                        for (int j = 0; j < seedStr.Length; j++)
                        {
                            char c = seedStr[j];
                            if (c != '(' && c != ')')
                            {
                                // ignore letters
                                continue;
                            }
                            // remove the current char
                            string modStr = seedStr.Substring(0, j) + seedStr.Substring(j + 1);
                            if (!visited.Contains(modStr))
                            {
                                q.Enqueue(modStr);
                                visited.Add(modStr);
                            }
                        }
                    }
                }
            }

            return results;
        }

        private bool IsValid(string s)
        {
            /* the trick to finding valid parenthesis
               is to count the number of left/open and right/close ones
               if the count of open-close == 0, then it is valid
               ex:
               ()  => open = 1, close = 1 : open-close = 0 ==> valid
               ()) => open = 1, close = 2 : open-close < 0 ==> invalid
               (() => open = 2, close = 1 : open-close > 0 ==> invalid
             */

            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == '(') count++;
                else if (c == ')') count--;
                if (count < 0) return false;
            }

            return count == 0;
        }
    }
}