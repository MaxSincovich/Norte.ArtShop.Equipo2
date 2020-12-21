using ArtShop.Entities.Model;
using ArtShop.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArtShop.Data;

namespace ArtShop.UI.Web.Controllers
{
    public class ArtistaController:Controller
    {
        ArtistaProcess artistaProcess = new ArtistaProcess();
        
        public ActionResult Index()
        {
            var lista = artistaProcess.List();
            return View(lista);
        }
        public ActionResult Create()
        {
            var user = System.Web.HttpContext.Current.Session["User"];
            if (user != null && Convert.ToInt32(user) == 2)
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create( Artist artist)
        {
            if (ModelState.IsValid)
            {
                var artRet = artistaProcess.Add(artist);

                if(artRet.Id != 0)
                    return RedirectToAction("Index");
            }
            return View(artist);
        }
        public ActionResult Edit(int? id)
        {
            var user = System.Web.HttpContext.Current.Session["User"];
            if (user != null && Convert.ToInt32(user) == 2)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Artist artist = artistaProcess.Get(id.Value);
                if (artist == null)
                {
                    return HttpNotFound();
                }

                return View(artist);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Artist artist)
        {
            if (ModelState.IsValid)
            {
                artistaProcess.Edit(artist);
                return RedirectToAction("Index");
            }
            return View(artist);
        }
        public ActionResult Delete(int id)
        {
            var user = System.Web.HttpContext.Current.Session["User"];
            if (user != null && Convert.ToInt32(user) == 2)
            {
                Artist artist = artistaProcess.Get(id);
                if (artist == null)
                {
                    return HttpNotFound();
                }
                return View(artist);
            }
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Artist artist)
        {
            if (artist.Id != 0)
            {
                artistaProcess.Remove(artist.Id);
                return RedirectToAction("Index");
            }
            return View(artist);
        }
    }
}