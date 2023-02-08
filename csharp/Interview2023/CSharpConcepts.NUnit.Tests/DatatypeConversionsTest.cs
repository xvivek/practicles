using CSharpConcepts.Prajim;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.NUnit.Tests
{
    [TestFixture]
    public class DatatypeConversionsTest
    {
        DatatypeConversions datatype;
        public DatatypeConversionsTest()
        {
            datatype = new DatatypeConversions();
        }

        [Test]
        public void ImplicitConversionToFloatTest_True()
        {
            Assert.IsTrue(datatype.ImplicitConversionToFloat(6));
        }

        [Test]
        public void ImplicitConversionToFloatTest_False()
        {
            Assert.False(datatype.ImplicitConversionToFloat(6, typeof(String)));
        }

        [Test]
        public void ExplicitConversionToIntTest_True()
        {
            Assert.True(datatype.ExplicitConversionToInt(6.78F));
        }

        [Test]
        public void Parse_True()
        {
            Assert.True(datatype.Parse(6.78F, typeof(float)));
        }

        [Test]
        public void Parse_False()
        {
            Assert.False(datatype.Parse(6.78F, typeof(int)));
        }
    }
}
