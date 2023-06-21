using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.NUnit.Tests
{
    [TestFixture]
    public class CompareProductsTest
    {
        [Test]
        public void compare_products_tests()
        {
            List<Products.Product> products1 = new List<Products.Product>();
            List<Products.Product> products2 = new List<Products.Product>();

            products1.Add(new Products.Product() {Id=1,Name="Product 1" });
            products1.Add(new Products.Product() { Id = 2, Name = "Product 2" });            

            products2.Add(new Products.Product() { Id = 2, Name = "Product 2a" });
            products2.Add(new Products.Product() { Id = 3, Name = "Product 3" });
            products2.Add(new Products.Product() { Id = 4, Name = "Product 4" });

            Products.ProductUpdate productUpdate = new Products.ProductUpdate();

            var result = productUpdate.GetUpdatedProducsts(products1, products2);

            Assert.AreEqual(productUpdate, productUpdate);

        }
    }
}
