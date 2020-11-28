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


        public ActionResult Index()
        {
            var lista = productProcess.List();
            return View(lista);
        }

        [HttpPost]
        public JsonResult AddCart(int? id)
        {
            var product = productProcess.Get(Convert.ToInt32(id));
            var cartResult = new Cart();
            var carItem = new CartItem();
            var listCarItem = new List<CartItem>();


            carItem.ProductId = product.Id;
            carItem.Price = product.Price;
            carItem.Quantity = 1;
            carItem.ChangedBy = "admin";
            carItem.ChangedOn = DateTime.Now;
            carItem.CreatedOn = DateTime.Now;
            
            if (Session["Cart"] == null || String.IsNullOrEmpty(Session["Cart"].ToString()))
            {
                cartResult = cartController.AddCart(listCarItem);
                carItem.CartId = cartResult.Id;
            }
            else
            {
                cartResult = cartController.GetCar();
                carItem.CartId = cartResult.Id;
            }
            listCarItem.Add(carItem);
            listCarItem = cartItemController.AddCart(listCarItem);
            return Json(cartResult, JsonRequestBehavior.AllowGet);
        }
    }
}