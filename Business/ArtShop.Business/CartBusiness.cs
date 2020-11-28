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
        public List<Cart> GeCart()
        {
            return db.Get();
        }
        public Cart GetCartbyCookie(string cookie)
        {
            return db.Get(c=>c.Cookie == cookie).FirstOrDefault();
        }
        public Cart EditCart(Cart cart)
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
