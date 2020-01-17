using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataStructureUtils
{
    class TrieNode
    {
        // Initialize your data structure here.
        public char Data;
        public bool IsEnd;
        public Dictionary<char, TrieNode> Neighbors;
        public TrieNode()
        {
            this.Data = '#';
            this.IsEnd = true;
            this.Neighbors = new Dictionary<char, TrieNode>();
        }

        public TrieNode(char ch)
        {
            this.Data = ch;
            this.IsEnd = false;
            this.Neighbors = new Dictionary<char, TrieNode>();
        }
    }
    public class Trie
    {
        private readonly TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        }

        /// <summary>
        /// Inserts a word in the Trie
        /// </summary>
        /// <param name="word"> Word to be inserted</param>
        /// <returns> void </returns>
        public void Insert(String word)
        {
            var start = root;
            foreach (var ch in word)
            {
                if (!start.Neighbors.ContainsKey(ch))
                {
                    var newnode = new TrieNode(ch);
                    start.Neighbors.Add(ch, newnode);
                }

                start = start.Neighbors[ch];
            }

            start.IsEnd = true;
        }

        /// <summary>
        /// Checks whether a word in Trie is present.
        /// </summary>
        /// <param name="word"> Word to be searched</param>
        /// <returns> bool </returns>
        public bool Search(string word)
        {
            var start = root;
            foreach (var ch in word)
            {
                if (!start.Neighbors.ContainsKey((ch)))
                {
                    return false;
                }

                start = start.Neighbors[ch];
            }

            return start.IsEnd;
        }

        /// <summary>
        /// Checks whether a word in Trie starts with given prefix.
        /// </summary>
        /// <param name="word"> Prefix to be searched.</param>
        /// <returns> bool </returns>
        public bool StartsWith(string word)
        {
            var start = root;
            foreach (var ch in word)
            {
                if (!start.Neighbors.ContainsKey((ch)))
                {
                    return false;
                }

                start = start.Neighbors[ch];
            }

            return true;
        }

      
    }

    

}
