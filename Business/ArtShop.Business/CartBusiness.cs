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
        public List<Cart> List()
        {
            List<Cart> result = default(List<Cart>);
            var cartDAC = new CartDAC();
            result = cartDAC.Select();
            return result;
        }



        public void Edit(Cart cart)
        {
            var cartDAC = new CartDAC();
            cartDAC.UpdateById(cart);
        }


        public Cart Get(int id)
        {
            var carttDAC = new CartDAC();
            var result = carttDAC.SelectById(id);
            return result;
        }

        public Cart Add(Cart cart)
        {
            Cart result = default(Cart);
            var cartDAC = new CartDAC();

            result = cartDAC.Create(cart);
            return result;
        }


        public void Remove(int id)
        {
            var cartitemDAC = new CartDAC();
            cartitemDAC.DeleteById(id);
        }











        //private BaseDataService<Cart> db = new BaseDataService<Cart>();
        //public List<Cart> GeCart()
        //{
        //    return db.Get();
        //}
        //public Cart GetCartbyCookie(string cookie)
        //{
        //    return db.Get(c=>c.Cookie == cookie).FirstOrDefault();
        //}
        //public Cart EditCart(Cart cart)
        //{
        //    return db.Update(cart, cart.Id);
        //}
        //public Cart GetById(int id)
        //{
        //    return db.GetById(id);
        //}
        //public Cart Create(Cart cart)
        //{
        //    return db.Create(cart);
        //}
        //public void Delete (int id)
        //{
        //    db.Delete(id);
        //}
    }
}
