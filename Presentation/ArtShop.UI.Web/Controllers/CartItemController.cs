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
            if (System.Web.HttpContext.Current.Session["Cart"] != null && (!String.IsNullOrEmpty(System.Web.HttpContext.Current.Session["Cart"].ToString())))
            {
                var idCart = System.Web.HttpContext.Current.Session["Cart"].ToString().Split('|');
                var listCartItem = CartItemProcess.GetbyCartId(Convert.ToInt32((idCart[1])));
                return listCartItem.Count();
            }
            else
            {
                return 0;
            }
        }
    }
}