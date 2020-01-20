using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureUtils
{
    public class SelectionSort
    {
       
        public static void Sort(dynamic DynamicArrayToSort,string Order="asc")
        {
            int arrayLength = DynamicArrayToSort.Length;
            for (int countIndex1 = 0; countIndex1 < arrayLength - 1; countIndex1++)
            {
                for (int countIndex2 = countIndex1 + 1; countIndex2 < arrayLength; countIndex2++)
                {
                    if (Order.ToLower() == "asc")
                    {
                        if (DynamicArrayToSort[countIndex1].CompareTo(DynamicArrayToSort[countIndex2])>=0)
                        {
                            var temp = DynamicArrayToSort[countIndex2];
                            DynamicArrayToSort[countIndex2] = DynamicArrayToSort[countIndex1];
                            DynamicArrayToSort[countIndex1] = temp;
                        }
                    }
                    else
                    {
                        if (DynamicArrayToSort[countIndex1].CompareTo(DynamicArrayToSort[countIndex2])<=0)
                        {
                            var temp = DynamicArrayToSort[countIndex2];
                            DynamicArrayToSort[countIndex2] = DynamicArrayToSort[countIndex1];
                            DynamicArrayToSort[countIndex1] = temp;
                        }
                    }
                }
            }
        }
    }

}
