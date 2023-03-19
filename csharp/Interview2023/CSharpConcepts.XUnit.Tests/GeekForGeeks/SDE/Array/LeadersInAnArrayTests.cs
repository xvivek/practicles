using CSharpConcepts.GeeksForGeeks.SDE.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CSharpConcepts.XUnit.Tests.GeekForGeeks.SDE.Array
{
    public class LeadersInAnArrayTests
    {

        [Fact]
        public void leader_in_array_test()
        {
            LeadersInAnArray l = new LeadersInAnArray();

            Assert.Equal(new List<int>(), l.GetLeaders(new List<int> ()));

            Assert.Equal(new List<int> { 17, 5, 2 }, l.GetLeaders(new List<int> { 16, 17, 4, 3, 5, 2 }));

            Assert.Equal(new List<int> { 5, 2 }, l.GetLeaders(new List<int> { 1, 2, 3, 4, 5, 2 }));


            
        }

        [Fact]
        public void leader_in_array_2_test()
        {
            LeadersInAnArray l = new LeadersInAnArray();

            Assert.Equal(new int[] { 17, 5, 2 }, l.GetLeaders2(new int[] { 16, 17, 4, 3, 5, 2 },6));
        }
    }
}
