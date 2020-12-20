using ArtShop.Business;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.UI.Process
{
    public class ProductProcess : ProcessComponent
    {

        public List<Product> List()
        {
            var response = HttpGet<List<Product>>("api/product/listar", new Dictionary<string, object>(), MediaType.Json);
            return response;
        }
        public Product Get(int id)
        {
            var response = HttpGet<Product>("api/product/buscar", new List<object>() { id }, MediaType.Json);
            return response;
        }

        public Product Add(Product product)
        {
            var response = HttpPost<Product>("api/product/agregar", product, MediaType.Json);
            return response;
        }

        public void Edit(Product product)
        {
            HttpPost<Product>("api/product/editar", product, MediaType.Json);
        }

        public void Remove(int productId)
        {
            HttpDelete<Product>("api/product/Eliminar", productId, MediaType.Json);
        }
    }
}
