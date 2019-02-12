using NUnit.Framework;
using System.Collections.Generic;

namespace General.Tests
{
    [TestFixture]
    public class LruCache01Tests
    {
        [Test]
        public void AddingAnItemShouldUpdateTheCache()
        {
            LruCache01<string, string> lru = new LruCache01<string, string>(3);
            lru.Add(new CacheItem<string, string>("one", "oneValue"));
            Assert.That(lru.CurrentCacheSize, Is.EqualTo(1));
            lru.Add(new CacheItem<string, string>("two", "twoValue"));
            lru.Add(new CacheItem<string, string>("three", "threeValue"));
            Assert.That(lru.CurrentCacheSize, Is.EqualTo(3));
        }

        [Test]
        public void VerifyThatAddingANewItemWillEvictFirstItemInLinkedList()
        {
            LruCache01<string, string> lru = CreateFullLru();
            lru.Add(new CacheItem<string, string>("four", "fourValue"));
            Assert.That(lru.LinkedList.Last.Value.Key, Is.EqualTo("four"));
        }

        [Test]
        public void VerifyThatAddingANewItemWillUnCacheLeastRecentlyUsedItem()
        {
            LruCache01<string, string> lru = CreateFullLru();
            lru.Add(new CacheItem<string, string>("four", "fourValue"));
            bool result = lru.Cache.TryGetValue("one", out LinkedListNode<CacheItem<string, string>> node);
            Assert.IsFalse(result);
        }

        [Test]
        public void VerifyThatGettingAnExistingItemFromTheCacheWillBeMovedToBackOfList()
        {
            LruCache01<string, string> lru = CreateFullLru();
            Assert.That(lru.LinkedList.First.Value.Key, Is.EqualTo("one"));
            string item = lru.Get("one");
            Assert.That(lru.LinkedList.First.Value.Key, Is.EqualTo("two"));
            Assert.That(lru.LinkedList.Last.Value.Key, Is.EqualTo("one"));
        }

        private LruCache01<string, string> CreateFullLru()
        {
            LruCache01<string, string> lru = new LruCache01<string, string>(3);
            lru.Add(new CacheItem<string, string>("one", "oneValue"));
            lru.Add(new CacheItem<string, string>("two", "twoValue"));
            lru.Add(new CacheItem<string, string>("three", "threeValue"));
            return lru;
        }
    }
}