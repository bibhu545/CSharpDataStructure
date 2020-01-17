using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureUtils
{
    public class PriorityQueue<T> 
    {
        // class defining Key-Value pair as each element in the priority queue
        // Key -> priority
        // Value -> object or some primitive type
        class Node
        {
            public int Priority { get; set; }
            public T Object { get; set; }
        }

        // object array
        List<Node> queue = new List<Node>();
        int heapSize = -1;
        bool _isMinPriorityQueue;

        // Size of the Priority Queue
        public int Count { get { return queue.Count; } }

        // If min priority queue or max priority queue
        public PriorityQueue(bool isMinPriorityQueue = false)
        {
            _isMinPriorityQueue = isMinPriorityQueue;
        }

        //Shows the Queue only with its values in the order of their priorities
        public string PrintQueue()
        {
            string strQueue = "";
            foreach (var item in queue)
            {
                strQueue += item.Object + " ";
            }
            return strQueue;
        }
        // Enqueue the object in the order of its priority
        public void Enqueue(int priority, T obj)
        {
            Node node = new Node() { Priority = priority, Object = obj };
            queue.Add(node);
            heapSize++;
            // Maintaining heap
            if (_isMinPriorityQueue)
                BuildMinHeap(heapSize);
            else
                BuildMaxHeap(heapSize);
        }

        // Dequeue the object with highest priority
        public T Dequeue()
        {
            if (heapSize > -1)
            {
                var returnVal = queue[0].Object;
                queue[0] = queue[heapSize];
                queue.RemoveAt(heapSize);
                heapSize--;
                // Maintaining lowest or highest at root based on min or max queue
                if (_isMinPriorityQueue)
                    MinHeapify(0);
                else
                    MaxHeapify(0);
                return returnVal;
            }
            else
                throw new Exception("Queue is empty");
        }

        // Updating the priority of specific object
        public void UpdatePriority(int priority, T obj)
        {
            for (int i = 0; i <= heapSize; i++)
            {
                Node node = queue[i];
                if(node.Object.Equals(obj))
                {
                    node.Priority = priority;
                    if (_isMinPriorityQueue)
                    {
                        BuildMinHeap(i);
                        MinHeapify(i);
                    }
                    else
                    {
                        BuildMaxHeap(i);
                        MaxHeapify(i);
                    }
                }
            }
        }

        // Searching an object
        public bool IsInQueue(T obj)
        {
            foreach (Node node in queue)
                if (object.ReferenceEquals(node.Object, obj))
                    return true;
            return false;
        }

        // Maintain max heap
        private void BuildMaxHeap(int i)
        {
            while (i >= 0 && queue[(i - 1) / 2].Priority < queue[i].Priority)
            {
                Swap(i, (i - 1) / 2);
                i = (i - 1) / 2;
            }
        }

        // Maintain min heap
        private void BuildMinHeap(int i)
        {
            while (i >= 0 && queue[(i - 1) / 2].Priority > queue[i].Priority)
            {
                Swap(i, (i - 1) / 2);
                i = (i - 1) / 2;
            }
        }

        // Position the node to its correct position as per Max Heap
        private void MaxHeapify(int i)
        {
            int left = GetLeftChild(i);
            int right = GetRightChild(i);

            int highest = i;

            if (left <= heapSize && queue[highest].Priority < queue[left].Priority)
                highest = left;
            if (right <= heapSize && queue[highest].Priority < queue[right].Priority)
                highest = right;

            if (highest != i)
            {
                Swap(highest, i);
                MaxHeapify(highest);
            }
        }

        // Position the node to its correct position as per Min Heap
        private void MinHeapify(int i)
        {
            int left = GetLeftChild(i);
            int right = GetRightChild(i);

            int lowest = i;

            if (left <= heapSize && queue[lowest].Priority > queue[left].Priority)
                lowest = left;
            if (right <= heapSize && queue[lowest].Priority > queue[right].Priority)
                lowest = right;

            if (lowest != i)
            {
                Swap(lowest, i);
                MinHeapify(lowest);
            }
        }

        // Swap between two nodes in the queue
        private void Swap(int i, int j)
        {
            var temp = queue[i];
            queue[i] = queue[j];
            queue[j] = temp;
        }

        // Get the left child node's index of the current node passed with its index
        private int GetLeftChild(int index)
        {
            return 2 * index + 1;
        }

        // Get the right child node's index of the current node passed with its index
        private int GetRightChild(int index)
        {
            return 2 * index + 2;
        }
    }
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        PriorityQueue<int> queue = new PriorityQueue<int>();
    //        Random rnd = new Random();
    //        // enqueue
    //        queue.Enqueue(5, 4);
    //        queue.Enqueue(3, 2);
    //        queue.Enqueue(9, 0);
    //        queue.Enqueue(8, 57);
    //        queue.Enqueue(6, 4);
    //        queue.Enqueue(1, -1);
    //        Console.WriteLine(queue.PrintQueue()); // Out: 0 57 4 2 4 -1

    //        // value in queue
    //        Console.WriteLine(queue.IsInQueue(78)); // Out: False

    //        // update
    //        queue.UpdatePriority(10,-1);
    //        Console.WriteLine(queue.PrintQueue()); // Out: -1 57 0 2 4 4 

    //        // dequeue
    //        while (queue.Count > 1)
    //        {
    //            Console.Write(queue.Dequeue() + " ");
    //        }
    //        Console.WriteLine(); // Out: -1 0 57 4 4
    //        Console.WriteLine(queue.PrintQueue()); // Out: 2
    //        Console.ReadLine();
    //    }
    //}
}
