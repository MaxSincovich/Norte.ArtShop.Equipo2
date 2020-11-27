using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ArtShop.Business;
using ArtShop.Entities.Model;

namespace ArtShop.Services.Http
{
    [RoutePrefix("api/User")]
    public class UserService : ApiController
    {

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Registrar")]
        public Users Register(Users user)
        {
            try
            {
                var uB = new UsersBusiness();
                return uB.Create(user);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Ingresar")]
        public Users LogIn(string userName, string password)
        {
            try
            {
                var uB = new UsersBusiness();
                var user = new Users();
                user.NombreUsuario = userName;
                user.Contraseña = password;
                return uB.Login(user);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }



    }
}
