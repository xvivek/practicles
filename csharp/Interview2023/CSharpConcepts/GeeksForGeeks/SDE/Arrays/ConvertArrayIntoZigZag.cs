using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.GeeksForGeeks.SDE.Arrays
{
    public class ConvertArrayIntoZigZag
    {
        public static int[] GetZigZagArray(int[] ints)
        {             
            Array.Sort(ints);
           
            for (int i=1; i< ints.Length-1; i = i + 2)
            {
                int tmp = ints[i];
                ints[i] = ints[i + 1];
                ints[i + 1] = tmp;
            }

            return ints;
        }


        public static int[] GetZigZagArray2(int[] ints)
        {
            Array.Sort(ints);
            bool flag = true;
            for (int i = 0; i < ints.Length - 1; i += 1)
            {               
                if (flag) 
                {
                    if (ints[i] > ints[i+1])
                    {
                        int temp = ints[i];
                        ints[i] = ints[i+1];
                        ints[i+1] = temp;

                    }
                }
                else 
                
                {
                    if (ints[i] < ints[i + 1])
                    {
                        int temp = ints[i];
                        ints[i] = ints[i + 1];
                        ints[i + 1] = temp;

                    }
                }
                flag=!flag;
            }

            return ints;
        }
      
    }
}
