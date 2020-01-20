using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataStructureUtils
{
    public class BubbleSort
    {
        public static void Sort(dynamic DynamicArrayToSort, string order = "asc")
        {
            int arrayLength = DynamicArrayToSort.Length;
            for (int countIndex1 = 0; countIndex1 < arrayLength - 1; countIndex1++)
            {
                for (int countIndex2 = 0; countIndex2 < arrayLength - countIndex1 - 1; countIndex2++)
                {
                    if (order.ToLower() == "asc")
                    {
                        if (DynamicArrayToSort[countIndex2 + 1].CompareTo(DynamicArrayToSort[countIndex2])<=0)
                        {
                            var temp = DynamicArrayToSort[countIndex2];
                            DynamicArrayToSort[countIndex2] = DynamicArrayToSort[countIndex2 + 1];
                            DynamicArrayToSort[countIndex2 + 1] = temp;
                        }
                    }
                    else
                    {
                        if (DynamicArrayToSort[countIndex2 + 1].CompareTo(DynamicArrayToSort[countIndex2])>=0)
                        {
                            var temp = DynamicArrayToSort[countIndex2];
                            DynamicArrayToSort[countIndex2] = DynamicArrayToSort[countIndex2 + 1];
                            DynamicArrayToSort[countIndex2 + 1] = temp;
                        }
                    }
                }
            }

        }
        private void Swap(dynamic arr, int index1, int index2)
        {
            var temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }
    }
}
