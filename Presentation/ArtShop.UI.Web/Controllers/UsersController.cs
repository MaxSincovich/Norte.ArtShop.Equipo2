using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArtShop.Entities.Model;
using ArtShop.UI.Process;

namespace ArtShop.UI.Web.Controllers
{
    public class UsersController : Controller
    {
        private UsersProcess userProcess = new UsersProcess();

        public ActionResult Index()
        {
            var lista = userProcess.List();
            return View(lista);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var usuario = userProcess.Get(id.Value);

            if(usuario ==null)
                return HttpNotFound();

            return View(usuario);
        }

        // POST: Bill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userProcess.Remove(id);
            return RedirectToAction("Index");
        }



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users user = userProcess.Get(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }

            ViewBag.IdTipoDeUsuarios = new SelectList(userProcess.GetTipoUsuarios(),"IdTipoUsuario","Descripcion");

            return View(user);
        }

        // POST: PurchaseInvoice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuario,IdTipoUsuario,NombreUsuario,FechaNacimiento,FechaCreacion,Dni,Nombre,Apellido,NombreUsuario,Contraseña")]Users user)
        {
            //purchaseInvoice.IdRegion = db.Country.Where(x => x.Id == purchaseInvoice.IdCountry).FirstOrDefault().IdRegion;
            if (ModelState.IsValid)
            {
                userProcess.Update(user);
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoDeUsuarios = new SelectList(userProcess.GetTipoUsuarios(), "IdTipoUsuario", "Descripcion");
            return View(user);
        }



        public ActionResult Create()
        {
            ViewBag.IdTipoDeUsuarios = new SelectList(userProcess.GetTipoUsuarios(), "IdTipoUsuario", "Descripcion");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoUsuario,NombreUsuario,FechaNacimiento,FechaCreacion,Dni,Nombre,Apellido,NombreUsuario,Contraseña")]Users user)
        {

            if (ModelState.IsValid)
            {
                int id = userProcess.Create(user).IdUsuario;
                if(id != 0)
                    return RedirectToAction("Index");
            }

            ViewBag.IdTipoDeUsuarios = new SelectList(userProcess.GetTipoUsuarios(), "IdTipoUsuario", "Descripcion");
            return View(user);
        }


    }
}