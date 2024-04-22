using Microsoft.AspNetCore.Mvc;
using ProyectoPrograAV2.Models;

namespace ProyectoPrograAV2.Controllers
{
    public class HistorialController : Controller
    {
        private readonly DemoContext _context;

        public HistorialController(DemoContext context)
        {
            _context = context;
        }
        public IActionResult historial()
        {
            return View();
        }
        public IActionResult HistorialUsuario(int id_usuario)
        {
            // Obtener el historial para el usuario especificado
            var historialUsuario = _context.historial.Where(h => h.id_usuario == id_usuario).ToList();
            if(historialUsuario == null)
            {
                return NotFound();
            }

            return View(historialUsuario);
        }
        [HttpPost]
        public IActionResult EliminarHistorial(int idHistorial)
        {
            var historial = _context.historial.Find(idHistorial);
            if (historial == null)
            {
                return NotFound(); // Manejar el caso de que el historial no exista
            }

            _context.historial.Remove(historial);
            _context.SaveChanges();

            return RedirectToAction("HistorialUsuario", new { idUsuario = historial.id_usuario });
        }
    }
}
