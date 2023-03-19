using CSharpConcepts.GeeksForGeeks.SDE.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CSharpConcepts.XUnit.Tests.GeekForGeeks.SDE.Array
{
    public class EquilibriumPointTest
    {

        [Fact]
        public void find_equilbm_element_test()
        { 
        
            EquilibriumPoint ep =  new EquilibriumPoint();

        //    Assert.Equal(2, ep.findElement3(new int[] { 1, 4, 2, 5, 0 },5));

      //      Assert.Equal(1, ep.findElement3(new int[] { 2, 3, 4, 1, 4, 5 }, 6));

            Assert.Equal(3, ep.findElement3(new int[] { 1, 3, 5, 2, 2 }, 5));

            

        }
    }
}
