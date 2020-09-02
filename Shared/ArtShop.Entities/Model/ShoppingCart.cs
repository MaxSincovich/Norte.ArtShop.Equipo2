using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Entities.Model
{
    public class ShoppingCart
    {
        public List <Product> Productos { get; set; }
        public double ValorFinal
        {
            get
            {
                return this.Productos.Select(x => x.Price).ToList().Sum();
            }
        }
    }
}
