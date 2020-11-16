using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ArtShop.Entities.Model;
using ArtShop.Services;
using ArtShop.UI.Process;
using ArtShop.UI.Web.App_Start;
using Microsoft.AspNet.Identity.Owin;

namespace ArtShop.UI.Web.Controllers

{
    public class AccountController : Controller
    {
        UsersProcess uP = new UsersProcess();

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;



        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Users user)
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

                var result = await SignInManager.PasswordSignInAsync(user.UserName, user.Contraseña, true, shouldLockout: false);
                switch (result)
                {
                    case SignInStatus.Success:
                        return RedirectToLocal("Home");
                     case SignInStatus.Failure:
                    default:
                        ModelState.AddModelError("", "Intento de inicio de sesión no válido.");
                        return View(user);
                }


                var userdb = uP.LogIn(user);

                if (userdb == null)
                {
                    ViewBag.ErrorMessage = "Los datos ingresados no son correctos";
                }
                else
                {
                    if (userdb.Contraseña == user.Contraseña || userdb.NombreUsuario == user.NombreUsuario)
                    {
                        FormsAuthentication.SetAuthCookie(user.NombreUsuario, true);
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


        private void IdentitySignIn(string userLogin)
        {
            var authTicket = new FormsAuthenticationTicket(1, userLogin, DateTime.Now,
                DateTime.Now.AddMinutes(30), true, "");

            string cookieContents = FormsAuthentication.Encrypt(authTicket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieContents)
            {
                Expires = authTicket.Expiration,
                Path = FormsAuthentication.FormsCookiePath
            };


        }


        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}