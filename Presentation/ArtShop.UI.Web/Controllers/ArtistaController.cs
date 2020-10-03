using ArtShop.Entities;
using ArtShop.Entities.Model;
using ArtShop.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtShop.UI.Web.Controllers
{
    public class ArtistaController : Controller
    {
        private ArtistaProcess process = new ArtistaProcess();
        public ActionResult Index()
        {
            var list = process.GetAll();
            return View(list);
        }



        public ActionResult Detalle(int id)
        {

            var ret = process.Get(id);
            return View(ret);
        }


        //public ActionResult CrearNuevo(Artist artist)
        //{
        //    ViewBag.showSuccessAlert = 2;
        //    if (!string.IsNullOrEmpty(artist.Id))
        //    {
        //        try
        //        {
        //            process.Set(artist);    
        //            ViewBag.showSuccessAlert = 1;
        //        }
        //        catch (Exception)
        //        {

        //            ViewBag.showSuccessAlert = 0;
        //        }

        //    }
        //    return View();

        //}


        public ActionResult Editar(int id)
        {
            if (id != 0)
            {
                var inventario = process.Get(id);
                return View(inventario);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Editar(Artist artist)
        {
            var _inventario = process.Edit(artist);
            if (_inventario != null)
            {
                return Redirect("~/Producto/Index");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}