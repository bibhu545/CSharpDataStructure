using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataUtils
{
    class GenericMinHeap
    {
        static void Main(string[] args)
        {
            MinHeap<int> heap = new MinHeap<int>();
            heap.AddItemToHeap(6);
            heap.AddItemToHeap(8);
            heap.AddItemToHeap(5);
            heap.AddItemToHeap(9);
            heap.AddItemToHeap(3);
            heap.AddItemToHeap(2);
            heap.Print();
            heap.RemoveMin();
            heap.Print();
            heap.UpdateElementByIndex(8, 3);
            heap.Print();
            heap.UpdateElement(3, 8);
            heap.Print();
            heap.UpdateElements(8, 1);
            heap.Print();
            Console.WriteLine(heap.IsInHeap(3));
            Console.ReadLine();
        }
    }

    public class MinHeap<T> where T : IComparable
    {
        // array
        private List<T> heap = new List<T>();

        // Size of the heap
        public int Count { get { return heap.Count; } }

        // Keeps track of the heap size starting with index 0
        int heapSize = -1;

        // Get minimum value of the heap
        public T Min { get { return heap.Count > 0 ? heap[0] : default(T);  } }

        // Add item to the heap
        public void AddItemToHeap(T item)
        {
            heap.Add(item);
            heapSize++;
            this.BuildMinHeap(heapSize);
        }
        
        //Prints the elements of min heap
        public void Print()
        {
            Console.WriteLine("Printing elements after inserting data:");
            foreach (var item in heap)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        // Remove the top of the Min Heap: as top of min heap has the smallest element
        public T RemoveMin()
        {
            if (Count > 0)
            {
                T item = heap[0];
                heap[0] = heap[heapSize];
                heap.RemoveAt(heapSize);
                heapSize--;
                this.MinHeapify(0);
                return item;
            }

            throw new InvalidOperationException("Heap is Empty");
        }

        // Remove the top of the Min Heap: as top of min heap has the smallest element
        public T RemoveTop()
        {
            return RemoveMin();
        }

        // Updates the value of the element which first matches with the value in the search result  
        public void UpdateElement(T currentItemValue, T valueToBeUpdated)
        {
            for (int i = 0; i <= heapSize; i++)
            {
                if (heap[i].Equals(currentItemValue))
                {
                    heap[i] = valueToBeUpdated;
                    BuildMinHeap(i);
                    MinHeapify(i);
                    break;
                }
            }
        }

        // Updates all the values of the elements which matches with the value in the search result  
        public void UpdateElements(T currentItemValue, T valueToBeUpdated)
        {
            for (int i = 0; i <= heapSize; i++)
            {
                if (heap[i].Equals(currentItemValue)){
                    heap[i] = valueToBeUpdated;
                    BuildMinHeap(i);
                    MinHeapify(i);
                }
            }
        }

        // Update only the value of the element at a specific index
        public void UpdateElementByIndex(int index, T valueToBeUpdated)
        {
            if(index <= heapSize && index > -1)
            {
                heap[index] = valueToBeUpdated;
                BuildMinHeap(index);
                MinHeapify(index);
            }
            else
            {
                throw new InvalidOperationException("Given index is greater than heap size");
            }

        }

        // Searching an element
        public bool IsInHeap(T element)
        {
            foreach (var item in heap)
                if (item.Equals(element))
                    return true;
            return false;
        }

        // Swap between two elements in the heap
        private void Swap(int i, int j)
        {
            var temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        // Maintain min heap
        private void BuildMinHeap(int index)
        {
            while (index >= 0 && heap[index].CompareTo(heap[(index - 1) / 2]) < 0)
            {
                Swap(index, (index - 1) / 2);
                index = (index - 1) / 2;
            }
        }

        // Position the element to its correct position as per Min Heap
        private void MinHeapify(int index)
        {
            int left = GetLeftChild(index);
            int right = GetRightChild(index);

            int lowest = index;

            if (left <= heapSize && heap[left].CompareTo(heap[lowest]) < 0)
                lowest = left;
            if (right <= heapSize && heap[right].CompareTo(heap[lowest]) < 0)
                lowest = right;

            if (lowest != index)
            {
                Swap(lowest, index);
                MinHeapify(lowest);
            }
        }

        // Get the left child's index of the current element passed with its index
        private int GetLeftChild(int index)
        {
            return 2 * index + 1;
        }

        // Get the right child's index of the current element passed with its index
        private int GetRightChild(int index)
        {
            return 2 * index + 2;
        }
    }
}
