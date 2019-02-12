using System.Collections.Generic;

namespace General
{
    public class DictionaryFlightItinerary
    {
        /*
         * Find Itinerary from a given list of tickets
         * NOTE: in this approach, the starting city is not provided - you have to determine it
         * https://www.geeksforgeeks.org/find-itinerary-from-a-given-list-of-tickets/
         *  alternative to doing this without backtracking
         */

        public List<List<string>> OrgDestPairs => new List<List<string>>
        {
            new List<string> {"hnl", "akl"},
            new List<string> {"yul", "ord"},
            new List<string> {"ord", "sfo"},
            new List<string> {"sfo", "hnl"},
        };

        public List<string> FlightItineraryUsingDictionary(List<List<string>> pairs)
        {
            // NOTE: in this example, YUL will be the starting point

            // build dictionary for given list
            Dictionary<string, string> orgDestMap = new Dictionary<string, string>();

            foreach (List<string> pair in pairs)
                orgDestMap[pair[0]] = pair[1];

            // build reverse dictionary
            Dictionary<string, string> orgDestMapReversed = new Dictionary<string, string>();
            foreach (List<string> pair in pairs)
                orgDestMapReversed[pair[1]] = pair[0];

            string start = null;

            /*
             * Traverse 'OrgDestPairs'.  For every key of OrgDestPairs, check if it
               is there in 'reverseMap'.  If a key is not present, then we
               found the starting point. In the above example, "yul" is
               starting point
             */

            foreach (List<string> pair in OrgDestPairs)
            {
                if (!orgDestMapReversed.ContainsKey(pair[0]))
                {
                    start = pair[0];
                    break;
                }
            }

            if (string.IsNullOrWhiteSpace(start)) return null;

            // now that we have a starting city, we can build the route

            string end = orgDestMap[start];
            List<string> results = new List<string>(pairs.Count + 1)
            {
                start, end
            };
            while (true)
            {
                bool next = orgDestMap.TryGetValue(end, out string nextStartingPoint);
                results.Add(nextStartingPoint);
                if (!next)
                    break;
                end = nextStartingPoint;
            }
            results.RemoveAt(results.Count - 1);
            return results;
        }
    }
}