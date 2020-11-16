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

        [HttpGet]
        public ActionResult Login()
        {
            return View();
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

        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(Users user)
        {
            try
            {
                var userdb = uP.Create(user);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error en el registro.";
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