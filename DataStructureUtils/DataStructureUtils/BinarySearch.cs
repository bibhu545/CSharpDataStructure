using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureUtils
{
    public class BinarySearch<T> where T : IComparable<T>
    {
        /// <summary>
        /// Generic type Binary Sort
        /// </summary>
        /// <param name="sortedData"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int FindIndex(T[] sortedData, T item)
        {
            var leftIndex = 0;
            var rightIndex = sortedData.Length - 1;

            while (leftIndex <= rightIndex)
            {
                var middleIndex = leftIndex + (rightIndex - leftIndex) / 2;

                if (item.CompareTo(sortedData[middleIndex]) > 0)
                {
                    leftIndex = middleIndex + 1;
                    continue;
                }

                if (item.CompareTo(sortedData[middleIndex]) < 0)
                {
                    rightIndex = middleIndex - 1;
                    continue;
                }

                return middleIndex;
            }

            return -1;
        }

    }

    /// <summary>
    /// To call BinarySearch Function Outsite the generic class
    /// </summary>
    public class CallBinarySearch
    {
        /// <summary>
        /// Binary Search for Integers
        /// </summary>
        /// <param name="array"></param>
        /// <param name="item"></param>
        /// <returns>index or -1</returns>
        public static int BinarySearch(int[] array, int item)
        {
            return BinarySearch<int>.FindIndex(array, item);
        }
        /// <summary>
        /// Binary Search for Strings
        /// </summary>
        /// <param name="array"></param>
        /// <param name="item"></param>
        /// <returns>index or -1</returns>
        public static int BinarySearch(string[] array, string item)
        {
            return BinarySearch<string>.FindIndex(array, item);
        }
        /// <summary>
        /// Binary Search for Doubles
        /// </summary>
        /// <param name="array"></param>
        /// <param name="item"></param>
        /// <returns>index or -1</returns>
        public static int BinarySearch(double[] array, double item)
        {
            return BinarySearch<double>.FindIndex(array, item);
        }
        /// <summary>
        /// Binary Search for Characters
        /// </summary>
        /// <param name="array"></param>
        /// <param name="item"></param>
        /// <returns>index or -1</returns>
        public static int BinarySearch(char[] array, char item)
        {
            return BinarySearch<char>.FindIndex(array, item);
        }
    }
}
