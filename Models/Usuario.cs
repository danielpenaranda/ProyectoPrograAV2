using System.ComponentModel.DataAnnotations;

namespace ProyectoPrograAV2.Models
{
    public class Usuario
    {
        [Key]
        public int id_usuario { get; set; }
        [Required]
        public string nombre { get; set; }

        public string email { get; set; }

        public string contrasena { get; set; }
        public DateTime ultimaConexion { get; set; }

        public bool estado { get; set; }

        public Usuario()
        {
            ultimaConexion = DateTime.Now; // Esto establece la fecha de última conexión al momento de la creación del objeto
        }
    }
}
