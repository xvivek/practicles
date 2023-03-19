using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.GeeksForGeeks.SDE.Arrays
{
    public class SortAnArrayOf0s1sAnd2s
    {

        public static int[] sort012(int[] a, int arr_size)
        {
            int lo = 0, mid=0, hi=arr_size-1,temp=0;

            while(mid<=hi)
            {
                switch (a[mid])
                {
                    case 0:
                        temp = a[lo];
                        a[lo] = a[mid];
                        a[mid] = temp;
                        lo++;
                        mid++;
                        break;
                    case 1:
                        mid++;
                        break;
                    case 2:
                        temp = a[mid];
                        a[mid] = a[hi];
                        a[hi] = temp;
                        hi--;
                        break;
                }
            }
            
            return a;
        }

    }
}
