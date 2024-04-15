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

            public string ContrasenaHash { get; set; }
            public DateTime ultimaConexion { get; set; }

            public bool estado { get; set; }

            public Usuario()
            {
                estado = true;
                ultimaConexion = DateTime.Now; // Esto establece la fecha de última conexión al momento de la creación del objeto
            }
            public void SetPassword(string password)
        {
            var hasher = new PasswordHasher<Usuario>();
            ContrasenaHash = hasher.HashPassword(this, password);
        }

            public bool CheckPassword(string password)
        {
            var hasher = new PasswordHasher<Usuario>();
            return hasher.VerifyHashedPassword(this, this.ContrasenaHash, password) == PasswordVerificationResult.Success;
        }
    }
    }
