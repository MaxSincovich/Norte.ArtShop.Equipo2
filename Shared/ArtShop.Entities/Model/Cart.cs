using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Entities.Model
{
    public class Cart : IdentityBase
    {
        public string UserId { get; set; }
        public DateTime CartDate { get; set; }
        public int ItemCount { get; set; }
        public string Comprado { get; set; }
        public List<CartItem> Items { get; set; }
    }
}
