using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Entities.Model
{
    public class Artist : IdentityBase
    {
        public Artist()
        {
            this.Products = new HashSet<Product>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string LifeSpan { get; set; }
        public string Country { get; set; }

        public string Description { get; set; }
        public int TotalProducts { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public virtual ICollection<Product> Products { get; set; }

    }
}
