using ArtShop.Business;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.UI.Process
{
    public class CartItemProcess : ProcessComponent
    {

   
        public CartItem Get(int id)
        {
            var response = HttpGet<CartItem>("api/CartItem/buscar", new List<object>() { id }, MediaType.Json);
            return response;
        }

        public CartItem Add(CartItem cartItem)
        {
            var response = HttpPost<CartItem>("api/CartItem/agregar", cartItem, MediaType.Json);
            return response;
        }

        public void Edit(CartItem cartItem)
        {
            HttpPost<CartItem>("api/CartItem/editar", cartItem, MediaType.Json);
        }
    }
}
