using System.Collections.Generic;

namespace InterviewTests.Pivotal
{
    public class MySet<T>
    {
        private readonly Dictionary<T, int> map;

        public MySet()
        {
            map = new Dictionary<T, int>();
        }

        public void Add(T key)
        {
            if (!Contains(key))
                map.Add(key, 0);
        }

        public bool Contains(T key)
        {
            return map.ContainsKey(key);
        }

        public void Remove(T key)
        {
            if (Contains(key))
                map.Remove(key);
        }
    }
}