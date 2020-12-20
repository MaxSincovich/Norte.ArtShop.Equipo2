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
        //public List<CartItem> List()
        //{
        //    List<CartItem> result = default(List<CartItem>);
        //    var cartitemDAC = new CartItemDAC();
        //    result = cartitemDAC.Select();
        //    return result;
        //}



        public void Edit(CartItem cartitem)
        {
            var cartitemDAC = new CartItemDAC();
            cartitemDAC.UpdateById(cartitem);
        }


        public CartItem Get(int id)
        {
            var cartitemDAC = new CartItemDAC();
            var result = cartitemDAC.SelectById(id);
            return result;
        }

        public List<CartItem> GetbyCartID(int id)
        {
            var cartitemDAC = new CartItemDAC();
            var result = cartitemDAC.Select(id);
            return result;
        }

        public CartItem Add(CartItem cartitem)
        {
            CartItem result = default(CartItem);
            var cartitemDAC = new CartItemDAC();

            result = cartitemDAC.Create(cartitem);
            return result;
        }


        public void Remove(int id)
        {
            var cartitemDAC = new CartItemDAC();
            cartitemDAC.DeleteById(id);
        }




        //private BaseDataService<CartItem> db = new BaseDataService<CartItem>();
        //public List<CartItem> GetProducts()
        //{
        //    return db.Get();
        //}



        //public CartItem EditProduct(CartItem cartItem)
        //{
        //    return db.Update(cartItem, cartItem.Id);
        //}


        //public CartItem GetById(int id)
        //{
        //    return db.GetById(id);
        //}

        //public List<CartItem> GetByIdCart(int idCart)
        //{
        //    return db.(c => c.CartId == idCart);
        //}
        //public CartItem Create(CartItem cartItem)
        //{
        //    return db.Create(cartItem);
        //}
        //public void Delete(int id)
        //{
        //    db.Delete(id);
        //}
    }
}
