using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProyectoPrograAV2.Models
{

        public class Usuario /*: IdentityUser*/
        {
            [Key]
            public int id_usuario { get; set; }
            public string nombreU { get; set; }

            public string email { get; set; }

            public string contrasena { get; set; }

            public DateTime ultimaConexion { get; set; }

            public bool estado { get; set; }

            public Usuario()
            {
                estado = true;
                ultimaConexion = DateTime.Now; // Esto establece la fecha de última conexión al momento de la creación del objeto
            }
      
    }
    }
