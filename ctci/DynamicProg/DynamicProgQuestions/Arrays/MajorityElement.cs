using System.Collections.Generic;

namespace Arrays
{
    /*
     * https://www.youtube.com/watch?v=zOyOwDEF1Rc&list=PLamzFoFxwoNjw4EpaVZzP-8lqWA9hOmnD&index=2
     */

    public class MajorityElement
    {
        public int GetMajorityElement(int[] elements)
        {
            Dictionary<int, MajorityElementPair> d = new Dictionary<int, MajorityElementPair>();

            for (int i = 0; i < elements.Length; i++)
            {
                if (d.ContainsKey(elements[i]))
                {
                    MajorityElementPair me = d[elements[i]];
                    me.Count++;
                    d[elements[i]] = me;
                }
                else
                {
                    d.Add(elements[i], new MajorityElementPair { Key = elements[i], Count = 1 });
                }
            }

            MajorityElementPair meMax = new MajorityElementPair();

            foreach (MajorityElementPair v in d.Values)
            {
                if (v.Count > meMax.Count) meMax = v;
            }

            int result = -1;
            if (meMax.Count > elements.Length / 2) result = meMax.Key;
            return result;
        }

        public struct MajorityElementPair
        {
            public int Count { get; set; }
            public int Key { get; set; }
        }
    }
}