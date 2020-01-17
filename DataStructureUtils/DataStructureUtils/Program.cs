using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureUtils
{
    class Program
    {
        static void Main(string[] args)
        {
            //Driver codes
            //For CutomStack class
            CustomStack customStack = new CustomStack();

            //For CustomQueue<T> class
            CustomQueue<int> customQueue = new CustomQueue<int>();

            //For PriorityQueue
            PriorityQueue<int> priQueue = new PriorityQueue<int>();

            //For MinHeap<T> class
            MinHeap<int> minHeap = new MinHeap<int>();

            //For MaxHeap<T> class
            MaxHeap<int> maxHeap = new MaxHeap<int>();

            //For Red-Black Tree
            RedBlackTree<int, string> redBlackTree = new RedBlackTree<int, string>();

            //For Searches

            //For Sortings

            //For BST
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();

            //For Trie
            Trie trie = new Trie();
            
            Console.ReadKey();
        }
    }
}
