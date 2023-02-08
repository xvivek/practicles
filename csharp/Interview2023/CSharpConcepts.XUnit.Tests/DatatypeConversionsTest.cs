using CSharpConcepts.Prajim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CSharpConcepts.XUnit.Tests
{

    public class DatatypeConversionsTest
    {
        DatatypeConversions datatype;
        public DatatypeConversionsTest()
        {
            datatype = new DatatypeConversions();
        }
        [Fact]
        public void ImplicitConversionToFloatTest_True()
        {
            Assert.True(datatype.ImplicitConversionToFloat(6));
        }

        [Fact]
        public void ImplicitConversionToFloatTest_False()
        {
            Assert.False(datatype.ImplicitConversionToFloat(6, typeof(String)));
        }

        [Fact]
        public void ExplicitConversionToIntTest_True()
        {
            Assert.True(datatype.ExplicitConversionToInt(6.78F));
        }
    }
}
