using System.ComponentModel.DataAnnotations;

namespace ProyectoPrograAV2.Models
{
    public class Carrito
    {
        [Key]
        public int id_carrito { get; set; }
        public int id_usuario { get; set; }
        public int id_producto { get; set; }
        public int cantidadProductos { get; set; }
        public DateTime fechaCompra {  get; set; }
    }
}
