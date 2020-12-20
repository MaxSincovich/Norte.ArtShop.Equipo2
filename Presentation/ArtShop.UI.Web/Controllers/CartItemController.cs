using ArtShop.Entities.Model;
using ArtShop.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtShop.UI.Web.Controllers
{
    public class CartItemController : Controller
    {
        CartItemProcess CartItemProcess = new CartItemProcess();
        public List<CartItem> AddCart(List<CartItem> ListcartItem)
        {
            var listCartItemResult = new List<CartItem>();
            foreach (var item in ListcartItem)
            {
                var CartItem = CartItemProcess.Add(item);
                listCartItemResult.Add(CartItem);
            }

            return ListcartItem;
        }
        public int Getcount()
        {
            var sessionCart = Session["Cart"];
            if (sessionCart != null && (!String.IsNullOrEmpty(sessionCart.ToString())))
            {
                return CartItemProcess.GetbyCartId(Convert.ToInt32(sessionCart.ToString().Split('|')[1])).Count();
            }
            else
            {
                return 0;
            }
        }

        [HttpGet]
        public CartItem getCartItembyProducto(int idProducto, int cartId)
        {            
            var cartItem = CartItemProcess.GetbyCartId(cartId).Where(a => a.ProductId == idProducto).FirstOrDefault();            
            return cartItem;
        }
    }
}