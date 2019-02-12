namespace General
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
}