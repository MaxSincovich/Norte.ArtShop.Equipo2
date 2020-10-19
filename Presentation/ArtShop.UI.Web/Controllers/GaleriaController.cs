using ArtShop.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtShop.UI.Web.Controllers
{
    public class GaleriaController:Controller
    {
        //public ActionResult Index()
        //{
        //    return View();
        //}
        ProductProcess productProcess = new ProductProcess();

        public ActionResult Index()
        {
            var lista = productProcess.GetAll();
            return View(lista);
        }
    }
}