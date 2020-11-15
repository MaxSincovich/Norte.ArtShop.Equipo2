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

        public Cart GetCar()
        {
            var id = Session["Cart"].ToString().Split('|');
            return CartProcess.Get(Convert.ToInt32(id));
        }
        public Cart AddCart(List<CartItem> cartItem)
        {


            HttpCookie cartCookie = new HttpCookie("MyCartCookie");
            var GuidCookie = Guid.NewGuid();
            //var _fecha = DateTime.Now.ToString("yyyy/MM/dd");
            cartCookie.Value = GuidCookie.ToString();
            var _car = new Cart()
            {
                CartDate = DateTime.Now,
                Cookie = cartCookie.Value,
                ItemCount = 1,
                //CartItem = cartItem,
                ChangedBy = "Admin",
                ChangedOn = DateTime.Now,
                CreatedBy = GuidCookie.ToString(),
                CreatedOn = DateTime.Now
            };
            var CartResult = CartProcess.Add(_car);
            if (CartResult != null)
                Session["Cart"] = cartCookie.Value + "|" + CartResult.Id;
            return CartResult;
        }
    }
}