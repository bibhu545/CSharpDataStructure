using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureUtils
{
    public class InsertionSort
    {
        public static void Sort(dynamic arr,string Order="asc")
        {
            int arrLength = arr.Length;
            for (int position = 1; position < arrLength; ++position)
            {
                var key = arr[position];
                int currentPosition = position - 1;

                // Move elements of arr[0..i-1], 
                // that are greater than key, 
                // to one position ahead of 
                // their current position 
                if (Order == "asc")
                {
                    while (currentPosition >= 0 && arr[currentPosition].CompareTo(key)>=0)
                    {
                        arr[currentPosition + 1] = arr[currentPosition];
                        currentPosition = currentPosition - 1;
                    }
                }
                else
                {
                    while (currentPosition >= 0 && arr[currentPosition].CompareTo(key) <= 0)
                    {
                        arr[currentPosition + 1] = arr[currentPosition];
                        currentPosition = currentPosition - 1;
                    }
                }
                arr[currentPosition + 1] = key;
            }
        }
    }
}
