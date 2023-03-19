using CSharpConcepts.GeeksForGeeks.SDE.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CSharpConcepts.XUnit.Tests.GeekForGeeks.SDE.Array
{
    public class SortAnArrayOf0s1sAnd2sTest
    {
        [Fact]
        public void SortAnArrayOf0s1_test() 
        {
            int[] arr = new int[] { 0, 1, 1, 0, 1, 2, 1, 2, 0, 0, 0, 1 };
            Assert.Equal(new int[] { 0, 0, 0, 0, 0, 1, 1, 1, 1,1, 2, 2 }, SortAnArrayOf0s1sAnd2s.sort012(arr, arr.Length));
        }
        
    }
}
