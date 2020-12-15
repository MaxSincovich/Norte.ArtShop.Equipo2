//====================================================================================================
// Código base generado con Visual Studio: (Build 1.0.1973)
// Layered Architecture Solution Guidance
// Generado por vcontreras - MCGA
//====================================================================================================

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;


namespace ArtShop.Entities.Model
{

    [DataContract]
    [Serializable]
    
    public partial class CartItem : IdentityBase
    {

        [DataMember]
        public int Id { get; set; }
        
        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public int CartId { get; set; }
        
        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public virtual Cart Cart { get; set; }

        [DataMember]
        public virtual Product Product { get; set; }
    }
}
