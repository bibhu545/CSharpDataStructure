using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureUtils
{
    public class MaxHeap<T> where T : IComparable
    {
        private List<T> heap = new List<T>();

        /// <summary>
        /// Size of the heap
        /// </summary>
        public int Count
        {
            get
            {
                return heap.Count;
            }
        }

        /// <summary>
        /// Keeps track of the heap size starting with index 0
        /// </summary>
        int heapSize = -1;

        /// <summary>
        /// Get minimum value of the heap
        /// </summary>
        public T Max
        {
            get
            {
                return heap.Count > 0 ? heap[0] : default(T);
            }
        }

        /// <summary>
        /// Add item to the heap
        /// </summary>
        /// <param name="item"></param>
        public void AddItemToHeap(T item)
        {
            heap.Add(item);
            heapSize++;
            this.BuildMaxHeap(heapSize);
        }

        /// <summary>
        /// Prints the elements of min heap
        /// </summary>
        /// <returns></returns>
        public String Show()
        {
            String result = "[";
            foreach (var item in heap)
            {
                result += item + ", ";
            }
            if(heap.Count > 0)
            {
                result = result.Substring(0, result.Length - 2);
            }
            result += "]";
            return result;
        }

        /// <summary>
        /// Remove the top of the Min Heap: as top of min heap has the smallest element
        /// </summary>
        /// <returns></returns>
        public T RemoveMax()
        {
            if (Count > 0)
            {
                T item = heap[0];
                heap[0] = heap[heapSize];
                heap.RemoveAt(heapSize);
                heapSize--;
                this.MaxHeapify(0);
                return item;
            }
            throw new InvalidOperationException("Heap is Empty");
        }

        /// <summary>
        /// Updates the value of the element which first matches with the value in the search result
        /// </summary>
        /// <param name="currentItemValue">Previous value</param>
        /// <param name="valueToBeUpdated">New value </param>
        public void UpdateElement(T currentItemValue, T valueToBeUpdated)
        {
            for (int i = 0; i <= heapSize; i++)
            {
                if (heap[i].Equals(currentItemValue))
                {
                    heap[i] = valueToBeUpdated;
                    BuildMaxHeap(i);
                    MaxHeapify(i);
                    break;
                }
            }
        }

        /// <summary>
        /// Update only the value of the element at a specific index
        /// </summary>
        /// <param name="index">Index where to be updated</param>
        /// <param name="valueToBeUpdated">value to be updated</param>
        public void UpdateElementByIndex(int index, T valueToBeUpdated)
        {
            if (index <= heapSize && index > -1)
            {
                heap[index] = valueToBeUpdated;
                BuildMaxHeap(index);
                MaxHeapify(index);
            }
            else
            {
                throw new InvalidOperationException("Given index is greater than heap size");
            }

        }

        /// <summary>
        /// Searching an element
        /// </summary>
        /// <param name="element">element to be searched</param>
        /// <returns>returns true if found</returns>
        public bool IsInHeap(T element)
        {
            foreach (var item in heap)
                if (item.Equals(element))
                    return true;
            return false;
        }

        /// <summary>
        /// Swap between two elements in the heap
        /// </summary>
        /// <param name="i">index of first element</param>
        /// <param name="j">index of second element</param>
        private void Swap(int i, int j)
        {
            var temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        /// <summary>
        /// Arrange heap after intertion
        /// </summary>
        /// <param name="index"></param>
        private void BuildMaxHeap(int index)
        {
            while (index >= 0 && heap[index].CompareTo(heap[(index - 1) / 2]) > 0)
            {
                Swap(index, (index - 1) / 2);
                index = (index - 1) / 2;
            }
        }

        /// <summary>
        /// Position the element to its correct position as per Min Heap
        /// </summary>
        /// <param name="index">Index on which Heapify would be applied</param>
        private void MaxHeapify(int index)
        {
            int left = GetLeftChild(index);
            int right = GetRightChild(index);

            int highest = index;

            if (left <= heapSize && heap[left].CompareTo(heap[highest]) > 0)
                highest = left;
            if (right <= heapSize && heap[right].CompareTo(heap[highest]) > 0)
                highest = right;

            if (highest != index)
            {
                Swap(highest, index);
                MaxHeapify(highest);
            }
        }

        /// <summary>
        /// Get the left child's index of the current element passed with its index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int GetLeftChild(int index)
        {
            return 2 * index + 1;
        }

        /// <summary>
        /// Get the right child's index of the current element passed with its index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int GetRightChild(int index)
        {
            return 2 * index + 2;
        }
    }
}
