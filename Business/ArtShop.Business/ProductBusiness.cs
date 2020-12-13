using ArtShop.Data;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Business
{
    public class ProductBusiness
    {

        public List<Product> List()
        {
            List<Product> result = default(List<Product>);
            var productDAC = new ProductDAC();
            result = productDAC.Select();
            return result;
        }

        public void Edit(Product product)
        {
            var productDAC = new ProductDAC();
            productDAC.UpdateById(product);
        }


        public Product Get(int id)
        {
            var productDAC = new ProductDAC();
            var result = productDAC.SelectById(id);
            return result;
        }

        public Product Add(Product product)
        {
            Product result = default(Product);
            var productDAC = new ProductDAC();

            result = productDAC.Create(product);
            return result;
        }


        public void Remove(int id)
        {
            var productDAC = new ProductDAC();
            productDAC.DeleteById(id);
        }


        public void AddImage(byte[] imageBytes, string name)
        {
            var productDAC = new ProductDAC();
            productDAC.AddImage(imageBytes, name);
        }






        //private BaseDataService<Product> db = new BaseDataService<Product>();
        //public List<Product> GetProducts()
        //{
        //    return db.Get();
        //}
        //public Product EditProduct(Product product)
        //{
        //    return db.Update(product, product.Id);
        //}
        //public Product GetById(int id)
        //{
        //    return db.GetById(id);
        //}
        //public Product Create(Product product)
        //{
        //    return db.Create(product);
        //}
        //public void Delete (int id)
        //{
        //    db.Delete(id);
        //}
    }
}
