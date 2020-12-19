using ArtShop.Entities.Model;
using ArtShop.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtShop.UI.Web.Controllers
{
    public class CartController : Controller
    {
        CartProcess CartProcess = new CartProcess();

        public Cart GetCart()
        {
            return CartProcess.Get(Convert.ToInt32(System.Web.HttpContext.Current.Session["Cart"].ToString().Split('|')[1]));
        }
        public Cart CreateCart()
        {
            HttpCookie cartCookie = new HttpCookie("MyCartCookie");
            var GuidCookie = Guid.NewGuid();
            cartCookie.Value = GuidCookie.ToString();
            var _car = new Cart()
            {
                CartDate = DateTime.Now,
                Cookie = cartCookie.Value,
                ItemCount = 1,
                CreatedBy = GuidCookie.ToString(),
                CreatedOn = DateTime.Now
            };
            var CartResult = CartProcess.Add(_car);
            if (CartResult != null)

                System.Web.HttpContext.Current.Session["Cart"] = cartCookie.Value + "|" + CartResult.Id;
            return CartResult;
        }
    }
}