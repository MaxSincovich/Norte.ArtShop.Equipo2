using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Entities.Model
{
    public class IdentityBase
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ChangedOn { get; set; }
        public string ChangedBy { get; set; }
    }
}