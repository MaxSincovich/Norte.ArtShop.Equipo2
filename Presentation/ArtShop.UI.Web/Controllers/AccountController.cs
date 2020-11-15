using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using ArtShop.Entities.Model;
using ArtShop.Services;

namespace ArtShop.UI.Web.Controllers

{
    public class AccountController : Controller
    {

        public ActionResult Login()
        {
            return View(new Users());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users user)
        {
            try
            {
                //TODO Coneccion a a BD
                /*
                  if (db.SEC_User.Where(x => x.UserName == user.UserName && x.IsActive).Any())
                  {
                      StringCypher sc = new StringCypher();
                      var realUser = db.SEC_User.Where(x => x.UserName == user.UserName && x.IsActive).First();


                      var psw = sc.DesEncriptar(realUser.Password);
                      if (psw == user.Password)
                      {
                          FormsAuthentication.SetAuthCookie(user.UserName, false);
                          return RedirectToAction("Index", "Home");
                      }
                      sc = null;
                  }
                  */
                var psw = "Metodo Que va a la bd a buscar el password de usuario";
                if (psw == user.Contraseña)
                {
                    FormsAuthentication.SetAuthCookie(user.NombreUsuario, false);
                    return RedirectToAction("Index", "Home");
                }

                ViewBag.ErrorMessage = "Los datos ingresados no son correctos";
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