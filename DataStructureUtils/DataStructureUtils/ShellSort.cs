using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureUtils
{
    public class ShellSort
    {
        public static void Sort(dynamic arr,string order="asc")
        {
            for(int gap=arr.Length/2;gap>=1;gap=gap/2)
            {
                for(int i=gap;i<arr.Length;i++)
                {
                    var temp = arr[i];
                    int j;
                    if(order=="asc")
                    {
                        
                        for (j = i; j >= gap && arr[j - gap].CompareTo(temp) >= 0; j -= gap)
                        {
                            arr[j] = arr[j - gap];
                        }
                            
                    }
                    else
                    {
                        for (j = i; j >= gap && arr[j - gap].CompareTo(temp) <= 0; j -= gap)
                        {
                            arr[j] = arr[j - gap];
                        }

                    }
                    arr[j] = temp;
                }
            }
        }
    }
}
