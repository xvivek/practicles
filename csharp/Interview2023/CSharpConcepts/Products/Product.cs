using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public enum UpdateType
    {
        ADD,
        UPDATE,
        DELETE,
        NONE
    }

    public class ProductUpdate
    {
        public Product Product { get; set; }
        public UpdateType UpdateType { get; set; } = UpdateType.NONE;

        public HashSet<ProductUpdate> GetUpdatedProducsts(List<Product> oldProducts, List<Product> newProducts)
        {
            HashSet<ProductUpdate> modified = new HashSet<ProductUpdate>();

            //if(newProducts==null || newProducts.Count==0)
            //    return modified;

            //if(oldProducts==null || oldProducts.Count == 0)
            //{
            //    newProducts.ForEach(i => modified.Add(new ProductUpdate() { Product = i, UpdateType = UpdateType.ADD }));
            //    return modified;
            //}

            newProducts.ForEach(i => {
               var product = oldProducts.FirstOrDefault(w => w.Id == i.Id);
                if(product!=null && product.Name!= i.Name)
                {
                    modified.Add(new ProductUpdate() { Product = product, UpdateType = UpdateType.UPDATE });
                }
                else if(product != null)
                {
                    modified.Add(new ProductUpdate() { Product = product, UpdateType = UpdateType.ADD });
                }
                else
                {
                    modified.Add(new ProductUpdate() { Product = i, UpdateType = UpdateType.ADD });
                }
            });

            oldProducts.Where(i => !newProducts.Any(n => n.Id == i.Id))?.ToList().ForEach(f=> modified.Add(new ProductUpdate() { Product = f,UpdateType=UpdateType.DELETE }));

            return modified;

        }
    }

}
