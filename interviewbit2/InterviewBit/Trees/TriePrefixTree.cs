namespace Trees
{
    public class TrieNode
    {
        public TrieNode(int capacity) => Nodes = new TrieNode[capacity];

        public bool IsEndOfWord { get; set; }
        public bool IsRoot { get; set; }
        public TrieNode[] Nodes { get; set; }
        public char Value { get; set; }
    }

    public class TriePrefixTree
    {
        /*
         208. Implement Trie (Prefix Tree) https://leetcode.com/problems/implement-trie-prefix-tree/
        Medium

        Implement a trie with insert, search, and startsWith methods.

        Example:

        Trie trie = new Trie();

        trie.insert("apple");
        trie.search("apple");   // returns true
        trie.search("app");     // returns false
        trie.startsWith("app"); // returns true
        trie.insert("app");
        trie.search("app");     // returns true

        Note:

            You may assume that all inputs are consist of lowercase letters a-z.
            All inputs are guaranteed to be non-empty strings.

         */

        private readonly int capacity;
        private readonly TrieNode root;
        /** Initialize your data structure here. */

        public TriePrefixTree(int capacity)
        {
            this.capacity = capacity;
            root = new TrieNode(capacity) { IsRoot = true };
        }

        public void Insert(string word) => InsertHelper(word, 0, root);

        public void InsertHelper(string word, int position, TrieNode r)
        {
            /** Inserts a word into the trie. */
            if (position == word.Length)
            {
                r.IsEndOfWord = true;
                return;
            }

            char currentChar = word[position];
            int index = GetIndexOfChar(currentChar);

            if (r.Nodes[index] != null && r.Nodes[index].Value == currentChar)
            {
                // skip already present nodes
                InsertHelper(word, position + 1, r.Nodes[index]);
            }
            else
            {
                r.Nodes[index] = new TrieNode(capacity) { Value = currentChar };
                InsertHelper(word, position + 1, r.Nodes[index]);
            }
        }

        public bool Search(string word)
        {
            /** Returns if the word is in the trie. */
            if (!BasicChecks(word)) return false;

            // otherwise lets recursively find the word
            bool result = SearchHelper(word, 0, root);
            return result;
        }

        public bool StartsWith(string prefix)
        {
            /** Returns if there is any word in the trie that starts with the given prefix. */
            if (!BasicChecks(prefix)) return false;
            bool result = StartsWithHelper(prefix, 0, root);
            return result;
        }

        private bool BasicChecks(string word)
        {
            if (string.IsNullOrWhiteSpace(word)) return false;
            if (root?.Nodes == null) return false;

            // if the first char isn't in the trie, return false
            int charIndex = GetIndexOfChar(word[0]);
            if (root.Nodes[charIndex] == null || root.Nodes[charIndex].Value != word[0]) return false;

            return true;
        }

        private int GetIndexOfChar(char c)
        {
            int index = (c - 'a') % capacity;
            return index;
        }

        private bool SearchHelper(string word, int position, TrieNode r)
        {
            if (position < word.Length)
            {
                int index = GetIndexOfChar(word[position]);
                if (r.Nodes[index] == null || word[position] != r.Nodes[index].Value)
                    return false;

                // check for the end of word flag
                if (position == word.Length - 1 && !r.Nodes[index].IsEndOfWord)
                    return false;

                return SearchHelper(word, position + 1, r.Nodes[index]);
            }
            return true;
        }

        private bool StartsWithHelper(string word, int position, TrieNode r)
        {
            if (position < word.Length)
            {
                int index = GetIndexOfChar(word[position]);
                if (r.Nodes[index] == null || word[position] != r.Nodes[index].Value)
                    return false;

                return StartsWithHelper(word, position + 1, r.Nodes[index]);
            }
            return true;
        }
    }
}