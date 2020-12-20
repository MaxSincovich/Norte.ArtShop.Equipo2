using ArtShop.Business;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.UI.Process
{
    public class CartProcess : ProcessComponent
    {
        public Cart Get(int id)
        {
            var response = HttpGet<Cart>("api/Cart/buscar", new List<object>() { id }, MediaType.Json);
            return response;
        }
        public Cart Add(Cart cart)
        {
            var response = HttpPost<Cart>("api/Cart/agregar", cart, MediaType.Json);
            return response;
        }
        public void Edit(Cart cart)
        {
            HttpPost<Cart>("api/Cart/editar", cart, MediaType.Json);
        }
        public Cart GetbyCookie(string cookie)
        {
            var response = HttpGet<Cart>("api/Cart/BuscarxCookie", new List<object>() { cookie }, MediaType.Json);
            return response;
        }
    }
}
