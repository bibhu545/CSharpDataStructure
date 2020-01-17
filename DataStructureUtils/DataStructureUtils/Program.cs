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

            //For MaxHeap<T> class
            MaxHeap<int> heap = new MaxHeap<int>();

            //For Red-Black Tree
            RedBlackTree<int, string> redBlackTree = new RedBlackTree<int, string>();

            Console.ReadKey();
        }
    }
}
