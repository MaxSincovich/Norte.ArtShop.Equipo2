using ArtShop.Business;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ArtShop.Services.Http
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/CartItem")]
    public class CartItemService : ApiController
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="CartItem"> </param>
        [HttpPost]
        [Route("Agregar")]
        public CartItem AddCart(CartItem cartItem)
        {
            try
            {
                var bc = new CartItemBusiness();
                return bc.Create(cartItem);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message + "+" + ex.InnerException
                };
                throw new HttpResponseException(httpError);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public void Edit(CartItem cartItem)
        {
            try
            {
                var bc = new CartItemBusiness();
                bc.EditProduct(cartItem);
            }
            catch (Exception ex)
            {
                // Repack to Http error.
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
        /// <param name="id"> </param>
        /// <returns></returns>
        [HttpGet]
        [Route("Buscar")]
        public CartItem Find(int id)
        {
            try
            {
                var bc = new CartItemBusiness();
                return bc.GetById(id);
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

        [HttpGet]
        [Route("BuscarItems/{idCart}")]
        public List<CartItem> FindItems(int idCart)
        {
            try
            {
                var bc = new CartItemBusiness();
                return bc.GetByIdCart(idCart);
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