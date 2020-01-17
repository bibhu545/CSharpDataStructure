using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureUtils
{
    public class LinearSearch<T> where T : IComparable<T>
    {
        /// <summary>
        /// Function to search the key
        /// </summary>
        /// <param name="data"></param>
        /// <param name="item"></param>
        /// <returns>int</returns>
        public static int FindIndex(T[] data, T item)
        {
            for (var i = 0; i < data.Length; i++)
            {
                if (item.CompareTo(data[i]) == 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }

    /// <summary>
    /// Class to call LinearSearch functions outside the generic class
    /// </summary>
    public class CallLinearSearch
    {
        /// <summary>
        /// Linear search for Integers
        /// </summary>
        /// <param name="array"></param>
        /// <param name="item"></param>
        /// <returns>index or -1</returns>
        public static int LinearSearch(Int32[] array, int item)
        {
            return LinearSearch<int>.FindIndex(array, item);
        }
        /// <summary>
        /// Linear search for Strings
        /// </summary>
        /// <param name="array"></param>
        /// <param name="item"></param>
        /// <returns>index or -1</returns>
        public static int LinearSearch(string[] array, string item)
        {
            return LinearSearch<string>.FindIndex(array, item);
        }
        /// <summary>
        /// Linear search for Doubles
        /// </summary>
        /// <param name="array"></param>
        /// <param name="item"></param>
        /// <returns>index or -1</returns>
        public static int LinearSearch(double[] array, double item)
        {
            return LinearSearch<double>.FindIndex(array, item);
        }

        /// <summary>
        /// Linear search for Characters
        /// </summary>
        /// <param name="array"></param>
        /// <param name="item"></param>
        /// <returns>index or -1</returns>
        public static int LinearSearch(char[] array, char item)
        {
            return LinearSearch<char>.FindIndex(array, item);
        }
    }
}
