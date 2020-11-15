using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Entities.Model
{
    [MetadataType(typeof(UserMetadata))]
    public partial class Users
    {
        public class UserMetadata
        {
            [DisplayName("Nombre de usuario")]
            [Required(ErrorMessage = "Nombre de usuario Requerido")]
            public string NombreUsuario { get; set; }


            [DisplayName("Contraseña")] [Required] public string Contraseña { get; set; }

            [DisplayName("Nombre")] [Required] public string Nombre { get; set; }

            [DisplayName("Apellido")] [Required] public string Apellido { get; set; }

            [DisplayName("DNI")] [Required] public string DNI { get; set; }

            public DateTime FechaNacimiento { get; set; }
            public DateTime FechaCreacion { get; set; }

            [DisplayName("Tipo de usuario")]
            [Required]
            public int IdTipoUsuario { get; set; }
        }
    }
}
