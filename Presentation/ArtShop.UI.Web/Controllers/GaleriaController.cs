﻿using ArtShop.Entities.Model;
using ArtShop.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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



        public ActionResult Create()
        {
            var artProcess = new ArtistaProcess();
            ViewBag.ArtistId = new SelectList(artProcess.List(),"Id", "LastName");

            return View();
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var productRet = productProcess.Add(product);

                if (productRet.Id != 0)
                    return RedirectToAction("Index");
            }


            var artProcess = new ArtistaProcess();
            ViewBag.ArtistId = new SelectList(artProcess.List(), "Id", "LastName", product.ArtistId);

            return View(product);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productProcess.Get(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }

            var artProcess = new ArtistaProcess();
            ViewBag.ArtistId = new SelectList(artProcess.List(), "Id", "LastName", product.ArtistId);
            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                productProcess.Edit(product);
                return RedirectToAction("Index");
            }


            var artProcess = new ArtistaProcess();
            ViewBag.ArtistId = new SelectList(artProcess.List(), "Id", "LastName",product.ArtistId);
            return View(product);
        }
        public ActionResult Delete(int id)
        {
            Product product = productProcess.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        //[HttpPost, ActionName("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product product)
        {
            if (product.Id != 0)
            {
                productProcess.Remove(product.Id);
                return RedirectToAction("Index");
            }

            return View(product);
        }


    }
}