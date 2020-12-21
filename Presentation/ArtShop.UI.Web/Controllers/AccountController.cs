using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.Security;
using ArtShop.Entities.Model;
using ArtShop.Services;
using ArtShop.UI.Process;

namespace ArtShop.UI.Web.Controllers

{
    public class AccountController : Controller
    {
        UsersProcess uP = new UsersProcess();

        public ActionResult Login()
        {
            if (System.Web.HttpContext.Current.Session["User"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users user)
        {
            try
            {
                var userdb = uP.LogIn(user);

                if (userdb == null)
                {
                    ViewBag.ErrorMessage = "Los datos ingresados no son correctos";
                }
                else
                {
                    if (userdb.Contraseña == user.Contraseña || userdb.NombreUsuario == user.NombreUsuario)
                    {
                        System.Web.HttpContext.Current.Session["User"] = userdb.IdTipoUsuario;
                        System.Web.HttpContext.Current.Session["UserMail"] = userdb.Email;
                        FormsAuthentication.SetAuthCookie(user.NombreUsuario, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                return View(user);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Los datos ingresados no son correctos.";
                return View(user);
            }
        }

        //[Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            System.Web.HttpContext.Current.Session["User"] = null;
            System.Web.HttpContext.Current.Session["UserMail"] = null;
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Create()
        {
            var user = System.Web.HttpContext.Current.Session["User"];
            if (user == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Users user)
        {
            user.DNI = "1";
            user.IdUsuario = 1;
            user.FechaNacimiento = DateTime.Now;
            user.FechaCreacion = DateTime.Now;

                var artRet = uP.Create(user);

            System.Web.HttpContext.Current.Session["User"] = artRet.IdTipoUsuario;
            System.Web.HttpContext.Current.Session["UserMail"] = artRet.Email;

            return RedirectToAction("Index", "Home");
        }
    }
}