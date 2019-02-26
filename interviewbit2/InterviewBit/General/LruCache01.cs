using System.Collections.Generic;

namespace General
{
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
            linkedList.AddFirst(lin);
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
                linkedList.AddFirst(node);
                return value;
            }

            return default(TV);
        }

        private LinkedListNode<CacheItem<TK, TV>> GetNodeToUnCache() => linkedList.Last;

        private void RemoveFromCache(TK key) => dictionary.Remove(key);

        private void RemoveNodeFromList() => linkedList.RemoveLast();
    }
}