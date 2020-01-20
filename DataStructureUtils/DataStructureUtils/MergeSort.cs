using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureUtils
{
    public class MergeSort
    {
        private static string Order{get;set;}

        /// <summary>
        /// Description:ArrayName and Sorting Order(asc,desc) 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="order">asc/desc</param>
        public static void Sort(dynamic arr,string order="asc")
        {
            Order =order;
            Mergesort(arr, 0, arr.Length-1);
        }

        private static void Mergesort(dynamic arr, int leftIndex, int rightIndex)
        {
           if(leftIndex < rightIndex)
            {

                int middleIndex = (leftIndex+rightIndex)/ 2;

                // Sort first and second halves 
                Mergesort(arr, leftIndex, middleIndex);
                Mergesort(arr, middleIndex+1, rightIndex);

                Merge(arr, leftIndex, middleIndex, rightIndex);
            }
        }

        private static void Merge(dynamic arr, int leftIndex, int middleIndex, int rightIndex)
        {
            int leftArrSize = middleIndex - leftIndex + 1;
            int rightArrSize = rightIndex - middleIndex;
            var leftSubArray = new dynamic[leftArrSize];
            var rightSubArray = new dynamic[rightArrSize];
            var tempArray = new dynamic[rightIndex - leftIndex + 1];
            for (int i = 0; i < leftArrSize; i++)
            {
                leftSubArray[i] = arr[leftIndex + i];
            }

            for (int i = 0; i < rightArrSize; i++)
            {
                rightSubArray[i] = arr[middleIndex + 1 + i];
            }


            int indexLeftSubArr = 0;
            int indexRightSubArr = 0;
            int indexMergedArr = 0;
            while (indexLeftSubArr < leftArrSize && indexRightSubArr < rightArrSize)
            {
                if (Order == "asc")
                {
                    if (leftSubArray[indexLeftSubArr].CompareTo(rightSubArray[indexRightSubArr]) <= 0)
                    {
                        tempArray[indexMergedArr] = leftSubArray[indexLeftSubArr];
                        indexLeftSubArr++;
                    }
                    else
                    {
                        tempArray[indexMergedArr] = rightSubArray[indexRightSubArr];
                        indexRightSubArr++;
                    }
                }
                else
                {
                    if (leftSubArray[indexLeftSubArr].CompareTo(rightSubArray[indexRightSubArr]) >= 0)
                    {
                        tempArray[indexMergedArr] = leftSubArray[indexLeftSubArr];
                        indexLeftSubArr++;
                    }
                    else
                    {
                        tempArray[indexMergedArr] = rightSubArray[indexRightSubArr];
                        indexRightSubArr++;
                    }
                }
                indexMergedArr++;
            }

            while (indexLeftSubArr < leftArrSize)
            {
                tempArray[indexMergedArr] = leftSubArray[indexLeftSubArr];
                indexLeftSubArr++;
                indexMergedArr++;
            }

            while (indexRightSubArr < rightArrSize)
            {
                tempArray[indexMergedArr] = rightSubArray[indexRightSubArr];
                indexRightSubArr++;
                indexMergedArr++;
            }

            for (int i = leftIndex; i <= rightIndex; i += 1)
            {
                arr[i] = tempArray[i - leftIndex];
            }
        }
    }
}
