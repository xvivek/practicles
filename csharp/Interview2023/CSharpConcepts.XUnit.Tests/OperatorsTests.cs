using CSharpConcepts.Prajim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CSharpConcepts.XUnit.Tests
{
    
    public class OperatorsTests
    {
        private CommonOperators operators;
        public OperatorsTests() 
        { 
            operators = new CommonOperators();
        }

        [Fact]
        public void assign_test()
        {
            Assert.Equal(6,operators.RetInt(6));
        }

        [Fact]
        public void get_quotient_test()
        {
            Assert.Equal(2, operators.GetQuotient(7, 3));
        }

        [Fact]
        public void get_reminer_test()
        {
            Assert.Equal(1, operators.GetReminder(7, 3));
        }

        [Fact]
        public void is_equal_test()
        {
            Assert.True(operators.IsEqual(6, 6));
        }

        [Fact]
        public void is_not_equal_test()
        {
            Assert.True(operators.NotEqual(5, 6));
        }

        [Fact]
        public void binary_and_opertor_test() 
        {

            Assert.True(operators.AndOperator(4, 4, 5, 5));

        }

        [Fact]
        public void binary_or_operator()
        {
            Assert.True(operators.OrOperator(5, 6, 7, 7));
        }

        [Fact]
        public void ternary_operator_test() 
        {
            Assert.True(operators.TernaryOperator(5, 5));
        }
    }
}
