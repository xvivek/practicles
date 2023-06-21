using CSharpConcepts.GeeksForGeeks.SDE.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CSharpConcepts.XUnit.Tests.GeekForGeeks.SDE.Array
{
    public class ConvertArrayIntoZigZagTest
    {
        [Fact]
        public void ZigZagArrayTest() 
        {
            int[] arr = { 4, 3, 7, 8, 6, 2, 1 };

          //  Assert.Equal(new int[] { 1, 3, 2, 6, 4, 8, 7 },   ConvertArrayIntoZigZag.GetZigZagArray(arr));

            Assert.Equal(new int[] { 1, 3, 2, 6, 4, 8, 7 }, ConvertArrayIntoZigZag.GetZigZagArray2(arr));
            
        }
    }
}
