using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Entities.Model
{
    public partial class Users
    {
        [DataMember]
        public int IdUsuario { get; set; }

        [DataMember]
        public string NombreUsuario { get; set; }

        [DataMember]
        public string Contraseña { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Apellido { get; set; }

        [DataMember]
        public string DNI { get; set; }

        [DataMember]
        public DateTime FechaNacimiento { get; set; }

        [DataMember]
        public DateTime FechaCreacion { get; set; }

        [DataMember]
        public int IdTipoUsuario { get; set; }

        [DataMember]
        public string Email { get; set; }

    }
}
