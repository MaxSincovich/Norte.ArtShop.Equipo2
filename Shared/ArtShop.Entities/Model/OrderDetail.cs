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
    [Serializable]
    public partial class OrderDetail : IdentityBase
    {
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public int Quantity { get; set; }

        public int OrderId { get; set; }
        [DataMember]
        public int ProductId { get; set; }

        public virtual Order Order { get; set; }

        [DataMember]
        public virtual Product Product { get; set; }
    }
}
