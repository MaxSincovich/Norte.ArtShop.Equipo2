using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ArtShop.Entities.Model;
using ArtShop.Business;

namespace Artshop.Services.Http
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/Artist")]
    public class ArtistService : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="artist"> </param>
        /// <returns></returns>
        [HttpPost]
        [Route("Agregar")]
        public Artist Add(Artist artist)
        {
            try
            {
                var bc = new ArtistBusiness();
                return bc.Add(artist);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    Content = new StringContent(ex.Message)
                };

                throw new HttpResponseException(httpError);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="artist"> </param>
        [HttpPut]
        [Route("Editar")]
        public void Edit(Artist artist)
        {
            try
            {
                var bc = new ArtistBusiness();
                bc.Edit(artist);
            }
            catch (Exception ex)
            {
                // Repack to Http error.
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    Content = new StringContent(ex.Message)
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
        public Artist Find(int id)
        {
            try
            {
                var bc = new ArtistBusiness();
                return bc.Get(id);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    Content = new StringContent(ex.Message)
                };

                throw new HttpResponseException(httpError);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Listar")]
        public List<Artist> List()
        {
            try
            {
                var bc = new ArtistBusiness();
                return bc.List();
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    Content = new StringContent(ex.Message)
                };

                throw new HttpResponseException(httpError);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="id"> </param>
        [HttpDelete]
        [Route("Eliminar")]
        public void Remove(int id)
        {
            try
            {
                var bc = new ArtistBusiness();
                bc.Remove(id);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    Content = new StringContent(ex.Message)
                };

                throw new HttpResponseException(httpError);
            }
        }
    }
}

