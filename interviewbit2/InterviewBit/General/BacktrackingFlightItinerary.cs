using System.Collections.Generic;

namespace General
{
    public class BacktrackingFlightItinerary
    {
        /*
         *https://www.dailycodingproblem.com/blog/an-introduction-to-backtracking/
         *
         * The flight itinerary problem is as follows:

           Given an unordered list of flights taken by someone, each represented as (origin, destination) pairs, and a starting airport, compute the person’s itinerary. If no such itinerary exists, return null. All flights must be used in the itinerary.

           For example, given the following list of flights:

           HNL ➔ AKL
           YUL ➔ ORD
           ORD ➔ SFO
           SFO ➔ HNL

           and starting airport YUL, you should return YUL ➔ ORD ➔ SFO ➔ HNL ➔ AKL.
         */

        public List<List<string>> OrgDestPairs => new List<List<string>>
        {
            new List<string> {"hnl", "akl"},
            new List<string> {"yul", "ord"},
            new List<string> {"ord", "sfo"},
            new List<string> {"sfo", "hnl"},
        };

        public List<string> BuildItinerary(List<List<string>> pairs)
        {
            List<string> results = new List<string>();
            List<List<string>> accumulator = new List<List<string>>();
            BuildItineraryHelper(OrgDestPairs, accumulator, results);

            return results;
        }

        public void BuildItineraryHelper(List<List<string>> pairs, List<List<string>> accumulator, List<string> results)
        {
            if (accumulator.Count == pairs.Count)
            {
                // base case, we have found an itinerary

                return;
            }
            else
            {
                for (int i = 0; i < pairs.Count; i++)
                {
                    // choose
                    List<string> current = pairs[0];
                    pairs.RemoveAt(0);
                    accumulator.Add(current);

                    // explore
                    BuildItineraryHelper(pairs, accumulator, results);

                    // un-choose
                    pairs.Insert(0, current);
                    accumulator.RemoveAt(accumulator.Count - 1);
                }
            }
        }
    }
}