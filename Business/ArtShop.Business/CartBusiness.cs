using ArtShop.Data;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Business
{
    public class CartBusiness
    {
        private BaseDataService<Cart> db = new BaseDataService<Cart>();
        public List<Cart> GetProducts()
        {
            return db.Get();
        }
        public Cart EditProduct(Cart cart)
        {
            return db.Update(cart, cart.Id);
        }
        public Cart GetById(int id)
        {
            return db.GetById(id);
        }
        public Cart Create(Cart cart)
        {
            return db.Create(cart);
        }
        public void Delete (int id)
        {
            db.Delete(id);
        }
    }
}
