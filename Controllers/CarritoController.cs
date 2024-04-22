using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProyectoPrograAV2.Models;

namespace ProyectoPrograAV2.Controllers
{
    public class CarritoController : Controller
    {
        private readonly DemoContext _context;

        public CarritoController(DemoContext context)
        {
            _context = context;
        }

        // Método para agregar un producto al carrito
        public IActionResult AgregarAlCarrito(int id_producto, int cantidadProductos)
        {
            var producto = _context.productos.Find(id_producto);

            if (producto != null)
            {
                decimal precioTotal = producto.precio * cantidadProductos;
                var nuevoElementoCarrito = new Carrito
                {
                    id_producto = id_producto,
                    cantidadProductos = cantidadProductos,
                    precioT = precioTotal,
                    fechaCompra = DateTime.Now 
                };
                _context.carrito.Add(nuevoElementoCarrito);
                _context.SaveChanges();

                return RedirectToAction("Carrito");
            }

            return RedirectToAction("Index", "Tienda"); 
        }

        // Método para mostrar los productos en el carrito
        public IActionResult Carrito()
        {
            var elementosCarrito = _context.carrito.ToList();

            var productosEnCarrito = new List<Producto>();
            foreach (var elemento in elementosCarrito)
            {
                var producto = _context.productos.Find(elemento.id_producto);
                if (producto != null)
                {
                    productosEnCarrito.Add(producto);
                }
            }
            return View(productosEnCarrito);
        }


        
        [HttpPost]
        public IActionResult ProcesarPago()
        {
            return RedirectToAction("ConfirmacionCompra");
        }

        public IActionResult ConfirmacionCompra()
        {
            return View();
        }
    }
}
