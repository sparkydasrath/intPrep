using System.Collections.Generic;
using System.Linq;

namespace DynamicProgQuestions
{
    // https://www.youtube.com/watch?v=yuRo0ttOF9E&index=21&list=PLamzFoFxwoNjtJZoNNAlYQ_Ixmm2s-CGX
    public class LongestSubsetOfConsecutiveNumbers
    {
        private readonly List<List<int>> results;

        public LongestSubsetOfConsecutiveNumbers() => results = new List<List<int>>();

        public int[] GetLargestSubset(int[] m)
        {
            // put array in dictionary
            Dictionary<int, int> d = m.ToDictionary(x => x, x => x);
            for (int i = 0; i < m.Length; i++)
            {
                int seqCheck = m[i] - 1;
                if (d.ContainsKey(seqCheck)) continue;

                List<int> subSeq = new List<int>();
                int seqStart = m[i];

                if (d.ContainsKey(seqStart))
                {
                    subSeq.Add(seqStart);
                    PopulateSubSequence(d, subSeq, seqStart);
                }
                if (subSeq.Count > 1)
                    results.Add(subSeq);
            }

            int maxLength = 0;
            List<int> maxSeq = new List<int>();
            foreach (List<int> r in results)
            {
                if (r.Count > maxLength)
                {
                    maxLength = r.Count;
                    maxSeq = r;
                }
            }

            return maxSeq.ToArray();
        }

        private void PopulateSubSequence(Dictionary<int, int> d, List<int> ss, int ssStart)
        {
            int next = ssStart + 1;
            if (!d.ContainsKey(next)) return;
            ss.Add(next);
            PopulateSubSequence(d, ss, next);
        }
    }
}