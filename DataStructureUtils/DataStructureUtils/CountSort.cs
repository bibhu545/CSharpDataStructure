using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureUtils
{
    public class CountSort
    {
        public static void Sort(int[]arr,string order="asc")
        {
            int[] outputArr = new int[arr.Length];
            int[] countArr = new int[arr.Max()+1];
            for (int i = 0; i < countArr.Length; ++i)
            {
                countArr[i] = 0;
            }

            //Making the element present how many times
            for(int i=0;i<arr.Length;i++)
            {
                ++countArr[arr[i]];
            }

            //Contains the actual position
            for (int i = 1; i < countArr.Length; ++i)
            {
                countArr[i] += countArr[i - 1];
            }

            for (int i = arr.Length-1; i >= 0; i--)
            {
                outputArr[countArr[arr[i]] - 1] = arr[i];
                --countArr[arr[i]];
            }

            if(order == "asc")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = outputArr[i];
                }
            }
            else
            {
                for (int i = 0,j=arr.Length-1; i < arr.Length; i++,j--)
                {
                    arr[i] = outputArr[j];
                }
            }
            
        }
    }
}
