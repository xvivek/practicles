using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpConcepts.Prajim;

namespace CSharpConceptsTests.CSharpTutorial.MsUnitTests.Services
{

    [TestClass]
    public class NullableTypes_IsNullTests
    {
        private NullableTypes nullableTypes;
        public NullableTypes_IsNullTests()
        {
            nullableTypes = new NullableTypes();
        }

        [TestMethod]
        public void NullableTypes_Nullable_NullValue()
        {
           Assert.AreEqual(nullableTypes.Nullable(null), 5);           
        }

        [TestMethod]
        public void NullableTypes_Nullable_IntValue()
        {
            Assert.AreEqual(nullableTypes.Nullable(6), 6);
        }
    }
}
