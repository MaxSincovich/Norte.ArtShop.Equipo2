using ArtShop.Business;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.UI.Process
{
    public class ProductProcess
    {
        private ProductBusiness bis = new ProductBusiness();
        public List<Product> GetAll()
        {
            return bis.GetProducts();
        }
        public Product Get(int id)
        {
            return bis.GetById(id);
        }

        public Product Create(Product product)
        {
            return bis.Create(product);
        }

        public Product Edit(Product product)
        {
            return bis.EditProduct(product);
        }
    }
}
