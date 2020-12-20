﻿using ArtShop.UI.Process;
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
            return View();
        }
    }
}