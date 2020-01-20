using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureUtils
{
    public class HeapSort
    {
        private static string Order { get; set; }
        public static void Sort(dynamic GenricArrayToSort,string order="asc")
        {
            Order = order;
            int arrLength = GenricArrayToSort.Length;
            for (int i = arrLength / 2 - 1; i >= 0; i--)
            {
                heapify(GenricArrayToSort, arrLength, i);
            }

            for (int i = arrLength - 1; i >= 0; i--)
            {
                Swap(GenricArrayToSort, 0, i);
                heapify(GenricArrayToSort, i, 0);
            }
        }

        private static void heapify(dynamic arr, int lastIndex, int curIndex)
        {
            int left = 2 * curIndex + 1;
            int right = 2 * curIndex + 2;
            int largest = curIndex;
            if (Order == "asc")
            {
                if (left < lastIndex && arr[left].CompareTo(arr[largest]) >= 0)
                {
                    largest = left;
                }
                if (right < lastIndex && arr[right].CompareTo(arr[largest])>=0)
                {
                    largest = right;
                }
            }
            else
            {

                if (left < lastIndex && arr[left].CompareTo(arr[largest]) <= 0)
                {
                    largest = left;
                }
                if (right < lastIndex && arr[right].CompareTo(arr[largest]) <= 0)
                {
                    largest = right;
                }
            }

            if (largest != curIndex)
            {
                Swap(arr, largest, curIndex);
                heapify(arr, lastIndex, largest);
            }
        }

        private static void Swap(dynamic arr, int index1, int index2)
        {
            var temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }
    }
}
