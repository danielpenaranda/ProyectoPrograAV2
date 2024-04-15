using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPrograAV2.Models;
using System;

namespace ProyectoPrograAV2.Controllers
{
    public class RegistroController : Controller
    {
        private readonly DemoContext _context;

        public RegistroController(DemoContext context)
        {
            _context = context;
        }
        public IActionResult registro()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SubmitForm(Usuario nuevoUsuario)
        {
            if (ModelState.IsValid && nuevoUsuario != null)
            {
              //  using (var context = new DemoContext()) //LINEA 19 DE ERROR
                //{
                    nuevoUsuario.ultimaConexion = DateTime.Now;
                    nuevoUsuario.estado = true;
                    _context.Add(nuevoUsuario);
                    await _context.SaveChangesAsync();
                    return View("..\\Login\\login");
                //}
            }
            return Content("<a> Algo salio mal :/ </a>");
        }
    }
}
