//====================================================================================================
// Código base generado con Visual Studio: (Build 1.0.1973)
// Layered Architecture Solution Guidance
// Generado por vcontreras - MCGA
//====================================================================================================


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;


namespace ArtShop.Entities.Model
{
    [DataContract]
    [Serializable]
    public partial class Product : IdentityBase
    {
        public Product()
        {
            this.CartItem = new HashSet<CartItem>();
            this.OrderDetail = new HashSet<OrderDetail>();
            this.Rating = new HashSet<Rating>();
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Image { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public int QuantitySold { get; set; }

        [DataMember]
        public double AvgStars { get; set; }
        public int ArtistId { get; set; }


        [DataMember]
        public virtual Artist Artist { get; set; }
        [DataMember]
        public virtual ICollection<CartItem> CartItem { get; set; }
        [DataMember]
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        [DataMember]
        public virtual ICollection<Rating> Rating { get; set; }


    }
}
