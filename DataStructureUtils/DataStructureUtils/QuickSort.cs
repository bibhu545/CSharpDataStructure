using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureUtils
{
    public class QuickSort
    {
        private static string Order { get; set; }

        public  static void Sort(dynamic arr ,string order="asc")
        {
            Order = order;
            Quicksort(arr, 0, arr.Length - 1);           
        }

        private static void Quicksort(dynamic arr, int low, int high)
        {
            if (low < high)
            {
                int pivot = partition(arr, low, high);

                Quicksort(arr, low, pivot - 1);  // Before pivot
                Quicksort(arr, pivot + 1, high); // After pivot
            }
        }

        private static int  partition(dynamic arr, int low, int high)
        {

            var pivot = arr[high];
            if (Order == "asc")
            {
                int lowerIndex = low - 1;
                for (int count = low; count <= high - 1; count++)
                {

                    if (arr[count].CompareTo(pivot) <= 0)
                    {
                        lowerIndex++;    // increment index of smaller element
                        Swap(arr, lowerIndex, count);
                    }

                }
                Swap(arr, lowerIndex + 1, high);
                return lowerIndex + 1;
            }
            else
            {
                int lowerIndex = low - 1;
                for (int count = low; count <= high - 1; count++)
                {

                    if (arr[count].CompareTo(pivot) >= 0)
                    {
                        lowerIndex++;    // increment index of smaller element
                        Swap(arr, lowerIndex, count);
                    }

                }
                Swap(arr, lowerIndex + 1, high);
                return lowerIndex + 1;
            }
        }

        private  static void Swap(dynamic arr, int index1, int index2)
        {
            var temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }
    }
}
