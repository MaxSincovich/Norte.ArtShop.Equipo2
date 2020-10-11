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
    public partial class Artist : IdentityBase
    {
        public Artist()
        {
            this.Product = new HashSet<Product>();
        }
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string LifeSpan { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int TotalProducts { get; set; }


        [DataMember]
        public virtual ICollection<Product> Product { get; set; }
    }
}