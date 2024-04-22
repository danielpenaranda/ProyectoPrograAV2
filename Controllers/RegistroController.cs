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
            if (nuevoUsuario != null)
            {
                _context.Add(nuevoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("login", "Login");  // Modificado para redirigir usando RedirectToAction
            }
            return Content("<a> Salio Mal</a>"); // Podrías considerar mejorar este mensaje de error.
        }

    }
}
