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
            if (Session["Cart"] != null && !String.IsNullOrEmpty(Session["Cart"].ToString()))
            {
                var id = System.Web.HttpContext.Current.Session["Cart"].ToString().Split('|');
                var cart = cartProcess.Get(Convert.ToInt32(id[1]));
                var lista = cartItemProcess.GetbyCartId(cart.Id);
                foreach (var item in lista)
                {
                    item.Product = productProcess.Get(item.ProductId);
                    item.Product.Artist = ArtistProcess.Get(item.Product.ArtistId);
                }
                return View(lista);
            }
            return View();

        }
        public ActionResult Compra()
        {
            return View();
        }
    }
}