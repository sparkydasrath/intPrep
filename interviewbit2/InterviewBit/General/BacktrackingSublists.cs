using System.Collections.Generic;
using Utils;

namespace General
{
    public class BacktrackingSublists
    {
        // https://www.youtube.com/watch?v=WshpHyZIWRE&index=10&input=PLT0wqqmbAFnfdRRCnzqY943MDyaNa3KSy
        /* Given [Jane, Bob, Matt, Sara] print all sub-lists
         * so it will look like [] [Jane] [Jane, Bob] etc
         */

        public static void Sublists(List<string> input)
        {
            List<string> chosen = new List<string>();
            SublistsHelper(input, chosen);
        }

        private static void SublistsHelper(List<string> input, List<string> chosen)
        {
            if (input.Count == 0)
            {
                ListUtils.PrintToConsole(chosen);
            }
            else
            {
                // the trick is this case is that it is not a simple permutation so you don't loop
                // over all the elements and add to a chosen input as it has more to do with order
                // instead each call should decide include or exclude

                // for each possible choice
                string s = input[0];
                input.RemoveAt(0);

                // need to handle whether to include current item and explore or exclude current item
                // and explore in this case, its a combo of choose/explore

                // choose/explore WITHOUT s
                SublistsHelper(input, chosen);

                // choose/explore WITH s
                chosen.Add(s);
                SublistsHelper(input, chosen);

                // un-choose current item
                input.Insert(0, s);
                // ListUtils.PrintToConsole(input);
                chosen.RemoveAt(chosen.Count - 1);
            }
        }
    }
}