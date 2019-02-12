using System.Collections.Generic;

namespace ReviewProblems
{
    /// <summary>
    /// Generic implementation of a LRU cache. The typical strategy is using a Dictionary and the
    /// built in .NET doubly linked list which is used to manage what is the oldest accessed item in
    /// the cache.
    /// NOTE: This is NOT a thread safe implementation
    /// </summary>
    /// <typeparam name="TK">Type of key to be used</typeparam>
    /// <typeparam name="TV">Type of value to store</typeparam>
    /// https://www.ebayinc.com/stories/blogs/tech/high-throughput-thread-safe-lru-caching/ https://stackoverflow.com/questions/754233/is-it-there-any-lru-implementation-of-idictionary
    public class CacheItem<TK, TV>
    {
        public CacheItem(TK key, TV value)
        {
            Key = key;
            Value = value;
        }

        public TK Key { get; set; }
        public TV Value { get; set; }
    }

    public class LruCache01<TK, TV>
    {
        private readonly Dictionary<TK, LinkedListNode<CacheItem<TK, TV>>> dictionary;
        private readonly LinkedList<CacheItem<TK, TV>> linkedList;
        private readonly int size;

        public LruCache01(int size)
        {
            this.size = size;
            dictionary = new Dictionary<TK, LinkedListNode<CacheItem<TK, TV>>>(size);
            linkedList = new LinkedList<CacheItem<TK, TV>>();
        }

        public Dictionary<TK, LinkedListNode<CacheItem<TK, TV>>> Cache => dictionary;
        public int CurrentCacheSize => dictionary.Count;

        public LinkedList<CacheItem<TK, TV>> LinkedList => linkedList;

        public void Add(CacheItem<TK, TV> ci)
        {
            // check if you exceed the size of the dictionary first
            if (dictionary.Count >= size)
            {
                // need to remove the LRU item from the linked list and from the cache
                LinkedListNode<CacheItem<TK, TV>> nodeToUnCache = GetNodeToUnCache();
                RemoveNodeFromList();
                RemoveFromCache(nodeToUnCache.Value.Key);
            }

            // create new linked list node
            LinkedListNode<CacheItem<TK, TV>> lin = new LinkedListNode<CacheItem<TK, TV>>(ci);
            // append to end of linked list
            linkedList.AddLast(lin);
            dictionary.Add(ci.Key, lin);
        }

        public TV Get(TK key)
        {
            if (dictionary.TryGetValue(key, out LinkedListNode<CacheItem<TK, TV>> node))
            {
                // the item in in the cache so return it
                TV value = node.Value.Value;

                // update the list and move this node to the back of the list
                linkedList.Remove(node);
                linkedList.AddLast(node);
                return value;
            }

            return default(TV);
        }

        private LinkedListNode<CacheItem<TK, TV>> GetNodeToUnCache() => linkedList.First;

        private void RemoveFromCache(TK key) => dictionary.Remove(key);

        private void RemoveNodeFromList() => linkedList.RemoveFirst();
    }
}