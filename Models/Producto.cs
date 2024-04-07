using System.ComponentModel.DataAnnotations;

namespace ProyectoPrograAV2.Models
{
    public class Producto
    {
        [Key]
        public int id_producto { get; set; } 
        //[Required]
        public string nombreProducto { get; set; } = null!;
        public string descripcion {  get; set; } = null!;
        public int cantidadProductos { get; set; }
        public DateOnly fechaPublicacion { get; set; }
        public decimal precio { get; set; }
        public decimal iva { get; set; }
        public decimal? descuento { get; set; }
        public string? imagen { get; set; }
        public bool? estado { get; set; }

    }
}
