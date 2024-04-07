using System.ComponentModel.DataAnnotations;

namespace ProyectoPrograAV2.Models
{
    public class Historial
    {
        [Key]
        public int id_historial { get; set; }
        public int id_usuario { get; set; }
        public int id_producto { get; set; }
        public int id_carrito { get; set; }
        public int cantidadTotal { get; set; }
        public decimal pagos { get; set; }
    }
}
