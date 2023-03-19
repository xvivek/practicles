using CSharpConcepts.GeeksForGeeks.SDE.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CSharpConcepts.XUnit.Tests.GeekForGeeks.SDE.Array
{
    public class ReverseArrayInGroupsTest
    {
        [Fact]
        public void reverse_array_in_groups_test()
        {
            Assert.Equal(new int[] { 3, 2, 1, 6, 5, 4, 9, 8, 7 }, ReverseArrayInGroups.sort(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 9, 3));
        }
    }
}
