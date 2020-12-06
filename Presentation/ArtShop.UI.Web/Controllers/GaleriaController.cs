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
        //public ActionResult Index()
        //{
        //    return View();
        //}
        ProductProcess productProcess = new ProductProcess();
        protected CartController cartController = new CartController();
        protected CartItemController cartItemController = new CartItemController();
        protected CartItemProcess CartItemProcess = new CartItemProcess();


        public ActionResult Index()
        {
            var lista = productProcess.List();
            return View(lista);
        }

        [HttpPost]
        public JsonResult AddCart(int? id, int? cantidad)
        {
            var product = productProcess.Get(Convert.ToInt32(id));
            var cartResult = new Cart();
            var carItem = new CartItem();
            var listCarItem = new List<CartItem>();


            carItem.ProductId = product.Id;
            carItem.Price = product.Price;
            carItem.Quantity = Convert.ToInt32(cantidad);
            carItem.ChangedBy = "admin";
            carItem.ChangedOn = DateTime.Now;
            carItem.CreatedOn = DateTime.Now;

            if (Session["Cart"] == null || String.IsNullOrEmpty(Session["Cart"].ToString()))
            {
                cartResult = cartController.AddCart(listCarItem);
                carItem.CartId = cartResult.Id;
                listCarItem.Add(carItem);
                listCarItem = cartItemController.AddCart(listCarItem);
            }
            else
            {
                cartResult = cartController.GetCar();
                carItem.CartId = cartResult.Id;
                var idCart = System.Web.HttpContext.Current.Session["Cart"].ToString().Split('|');
                var _cartItem = cartItemController.getCartItembyProducto(product.Id, Convert.ToInt32((idCart[1])));
                if (_cartItem != null)
                {
                    _cartItem.Quantity += Convert.ToInt32(cantidad);
                    carItem = CartItemProcess.Edit(_cartItem);
                }
                else
                {
                    listCarItem.Add(carItem);
                    listCarItem = cartItemController.AddCart(listCarItem);
                }

            }
            

            return Json(cartResult, JsonRequestBehavior.AllowGet);
        }



    }
}