using System;
using System.Linq;
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
            //return View(new Users());
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
                        FormsAuthentication.SetAuthCookie(user.NombreUsuario, false);
                        return RedirectToAction("Index", "Home");
                    }
                }
                //var psw = "Metodo Que va a la bd a buscar el password de usuario";       
                return View(user);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Los datos ingresados no son correctos, Error.";
                return View(user);
            }
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }





    }
}