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
        public CartItem Edit(CartItem cartItem)
        {
            var response = HttpPost<CartItem>("api/CartItem/editar", cartItem, MediaType.Json);
            return response;
        }
        public List<CartItem> GetbyCartId( int cartId)
        {
            var response = HttpGet<List<CartItem>>($"api/CartItem/BuscarItems/{cartId}", new Dictionary<string, object>(), MediaType.Json);
            return response;
        }
        public void Remove(int id)
        {
            HttpDelete<Artist>("api/CartItem/Eliminar", id, MediaType.Json);
        }
    }
}