using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.Prajim
{
    public class ClassArray
    {

        int[] ints;

        public ClassArray(int length)
        {
            ints = new int[length];
        }
      
        public void Set(int index, int value)
        {        
            ints[index] = value;
        }

        public int GetIndexValue(int index)
        {
            if(ints.Length < index)
            {
                throw new ArgumentException("Invalid index parameter");
            }

            return ints[index];
        }

    }
}
