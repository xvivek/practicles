using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.GeeksForGeeks.SDE.Arrays
{
    public class ReverseArrayInGroups
    {
        public static int[] sort(int[] a, int n,int k)
        {
            int lo = 0, hi = 0;

            for(int i=0;i<n;i+=k)
            {
                lo = i;
                hi =Math.Min(i + k - 1, n-1);

                while (lo < hi)
                {
                    int temp = a[lo];
                    a[lo] = a[hi];
                    a[hi] = temp;

                    lo++;
                    hi--;                  
                }    
            }

            return a;
        }
    }
}
