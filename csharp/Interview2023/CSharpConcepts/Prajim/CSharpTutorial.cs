using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.Prajim
{
    public class NullableTypes
    {
        public int Nullable(int? @int)
        {
            int i;
            int? ni = @int;

            if (ni == null)
            {
                i = 5;
            }
            else
            {
                i = ni.Value;
                i = (int)ni;
            }
           
            return i;
        }

        public void NullCollasingOperator()
        {

        }
    }
}
