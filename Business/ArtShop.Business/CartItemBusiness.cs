using ArtShop.Data;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Business
{
    public class CartItemBusiness
    {
        private BaseDataService<CartItem> db = new BaseDataService<CartItem>();
        public List<CartItem> GetProducts()
        {
            return db.Get();
        }
        public CartItem EditProduct(CartItem cartItem)
        {
            return db.Update(cartItem, cartItem.Id);
        }
        public CartItem GetById(int id)
        {
            return db.GetById(id);
        }
        public CartItem Create(CartItem cartItem)
        {
            return db.Create(cartItem);
        }
        public void Delete (int id)
        {
            db.Delete(id);
        }
    }
}
