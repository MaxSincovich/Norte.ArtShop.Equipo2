using ArtShop.Entities.Model;
using ArtShop.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtShop.UI.Web.Controllers
{
    public class GaleriaController : Controller
    {
        ProductProcess productProcess = new ProductProcess();
        protected CartController cartController = new CartController();
        protected CartItemProcess CartItemProcess = new CartItemProcess();
        protected CartProcess CartProcess = new CartProcess();
        public ActionResult Index()
        {
            var lista = productProcess.List();
            return View(lista);
        }

        [HttpPost]
        public JsonResult AddCart(int? id, int? cantidad)
        {
            var Cart = new Cart();
            var sesionCart = Session["Cart"];
            if (sesionCart == null || String.IsNullOrEmpty(sesionCart.ToString()))
            {
                Cart = cartController.CreateCart();
                CartItemProcess.Add(new CartItem()
                {
                    ProductId = Convert.ToInt32(id),
                    Price = productProcess.Get(Convert.ToInt32(id)).Price,
                    Quantity = Convert.ToInt32(cantidad),
                    CartId = Cart.Id,
                    CreatedBy = "admin",
                    CreatedOn = DateTime.Now
                });
            }
            else
            {
                Cart = CartProcess.Get(Convert.ToInt32(sesionCart.ToString().Split('|')[1]));
                CartItemProcess.Add(new CartItem()
                {
                    ProductId = Convert.ToInt32(id),
                    Price = productProcess.Get(Convert.ToInt32(id)).Price,
                    Quantity = Convert.ToInt32(cantidad),
                    CartId = Cart.Id,
                    CreatedBy = "admin",
                    CreatedOn = DateTime.Now
                });
            }
            return Json(Cart, JsonRequestBehavior.AllowGet);
        }
    }
}