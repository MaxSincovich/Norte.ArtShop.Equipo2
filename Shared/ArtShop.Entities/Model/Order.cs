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
    
    public partial class Order : IdentityBase
    {
        [DataMember]
        public DateTime OrderDate { get; set; }
        [DataMember]
        public double TotalPrice { get; set; }
        [DataMember]
        public int OrderNumber { get; set; }
        [DataMember]
        public int ItemCount { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
