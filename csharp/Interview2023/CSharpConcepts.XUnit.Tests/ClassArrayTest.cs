using CSharpConcepts.Prajim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CSharpConcepts.XUnit.Tests
{

    public class ClassArrayTest
    {
        private ClassArray @array;
        public ClassArrayTest()
        {
            array = new ClassArray(5);
        }

        [Fact]
        public void GetValueTest()
        {

            array.Set(0, 1);
            array.Set(1, 2);
            array.Set(2, 3);
            array.Set(3, 4);
            array.Set(4, 5);

            Assert.Equal(2, @array.GetIndexValue(1));
            
        }
    }
}
