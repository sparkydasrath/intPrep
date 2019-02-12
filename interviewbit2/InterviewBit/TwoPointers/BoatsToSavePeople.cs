using System;

namespace TwoPointers
{
    public class BoatsToSavePeople
    {
        /*
         * 881. Boats to Save People https://leetcode.com/problems/boats-to-save-people/
            Medium

            The i-th person has weight people[i], and each boat can carry a maximum weight of limit.

            Each boat carries at most 2 people at the same time, provided the sum of the weight of those people is at most limit.

            Return the minimum number of boats to carry every given person.  (It is guaranteed each person can be carried by a boat.)

            Example 1:

            Input: people = [1,2], limit = 3
            Output: 1
            Explanation: 1 boat (1, 2)

            Example 2:

            Input: people = [3,2,2,1], limit = 3
            Output: 3
            Explanation: 3 boats (1, 2), (2) and (3)

            Example 3:

            Input: people = [3,5,3,4], limit = 5
            Output: 4
            Explanation: 4 boats (3), (3), (4), (5)

            Note:

                1 <= people.length <= 50000
                1 <= people[i] <= limit <= 30000

         */

        public int NumRescueBoats(int[] people, int limit)
        {
            // leetcode solution: https://leetcode.com/problems/boats-to-save-people/
            Array.Sort(people);
            int first = 0, second = people.Length - 1;
            int boats = 0;

            while (first <= second)
            {
                boats++;
                if (people[first] + people[second] <= limit) first++;
                second--;
            }

            return boats;
        }

        public int NumRescueBoatsMine(int[] people, int limit)
        {
            // fucking christ - these solutions are so simple compared to what I come up with fuck me
            // fuck me fuck me fuck all this google fb prep bs so much utter non stop fucking bs

            if (people == null) return 0;
            if (people.Length == 1 && people[0] <= limit) return 1;
            if (people.Length == 1 && people[0] > limit) return 0;

            /*
                The idea is to use two pointers to iterate the list and find the best candidates to add to the limit
                once found, zero out those candidates
            */

            int boats = 0;

            for (int first = 0; first < people.Length; first++)
            {
                // check if just one person is the limit
                if (people[first] == limit)
                {
                    boats++;
                    people[first] = 0; // zero out used people
                }
                else
                {
                    /* check two people
                        can't take the first pair found - need to walk the whole list and find the max weight that can be added to the first
                        without exceeding the limit

                        if you can't find anyone, then only that person can get into the boat;

                    */

                    int second = first + 1;

                    // case for when we search through the window and there is no viable second
                    // person and only the first person is remaining if (first == people.Length &&
                    // second >= people.Length && people[first] != 0) { boats++; break; }

                    while (second < people.Length)
                    {
                        int sum = people[first] + people[second];

                        if (sum == limit)
                        {
                            boats++;
                            people[second] = 0;
                            second++;
                        }
                        else if (sum < limit)
                        {
                            // extend the search window to see if another person exists that can fit
                            // into the boat
                            second++;
                            if (people[second] == 0) continue; // skip out potential already chosen people
                        }
                        else
                        {
                            // means we haven't found a pair of people to put into the boat so need
                            // to put only the first person in and break out of this loop
                            boats++;
                            people[first] = 0;
                            break;
                        }
                    }
                }
            }

            return boats;
        }
    }
}