using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.Prajim
{
    public class CommonOperators
    {
        public int RetInt(int x)
        {
            int y = x;
            return y; 
        }

        public int GetQuotient(int x, int y)
        {
            return x / y;
        }

        public int GetReminder(int x, int y)
        {
            return x % y;
        }

        public bool IsEqual(int x, int y)
        {
            return x == y;
        }

        public bool NotEqual(int x, int y)
        {
            return x != y;
        }

        public bool AndOperator(int x1,int x2, int y1, int y2)
        {
            return x1 == x2 && y1 == y2;
        }

        public bool OrOperator(int x1, int x2, int y1, int y2)
        {
            return x1 == x2 || y1 == y2;
        }

        public bool TernaryOperator(int x, int y)
        {
            return x == y ? true : false;
        }
    }

}
