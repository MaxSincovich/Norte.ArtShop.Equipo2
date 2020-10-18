using ArtShop.Entities.Model;
using ArtShop.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace ArtShop.UI.Web.Controllers
{
    public class ArtistaController:Controller
    {
        ArtistaProcess artistaProcess = new ArtistaProcess();
        
        public ActionResult Index()
        {
            var lista = artistaProcess.GetAll();
            return View(lista);
        }
    }
}