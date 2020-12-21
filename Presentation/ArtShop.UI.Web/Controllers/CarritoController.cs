using ArtShop.Entities.Model;
using ArtShop.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtShop.UI.Web.Controllers
{
    public class CarritoController : Controller
    {
        CartProcess cartProcess = new CartProcess();
        CartItemProcess cartItemProcess = new CartItemProcess();
        ProductProcess productProcess = new ProductProcess();
        ArtistaProcess ArtistProcess = new ArtistaProcess();
        // GET: Carrito
        public ActionResult Index()
        {
            var sessionCart = Session["Cart"];
            var User = Session["User"];

            if (sessionCart == null && String.IsNullOrEmpty(sessionCart.ToString()))
            {
                return RedirectToAction("Index", "Home");
            }
            if (User == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (sessionCart != null && !String.IsNullOrEmpty(sessionCart.ToString()))
            {
                var lista = cartItemProcess.GetbyCartId(cartProcess.Get(Convert.ToInt32(sessionCart.ToString().Split('|')[1])).Id);
                foreach (var item in lista)
                {
                    item.Product = productProcess.Get(item.ProductId);
                    item.Product.Artist = ArtistProcess.Get(item.Product.ArtistId);
                }
                return View(lista);
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Compra()
        {
            var User = Session["User"];

            //if (sessionCart == null && String.IsNullOrEmpty(sessionCart.ToString()))
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            if (User == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
            //return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Compra(Order orden)
        {
            var User = Session["User"];

            //if (sessionCart == null && String.IsNullOrEmpty(sessionCart.ToString()))
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            if (User == null)
            {
                return RedirectToAction("Login", "Account");
            }
            Session["Cart"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}