using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPrograAV2.Models;
using System;

namespace ProyectoPrograAV2.Controllers
{
    public class RegistroController : Controller
    {
        public IActionResult registro()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SubmitForm(Usuario nuevoUsuario)
        {
            if (ModelState.IsValid && nuevoUsuario != null)
            {
                using (var context = new DemoContext())
                {
                    nuevoUsuario.ultimaConexion = DateTime.Now;
                    nuevoUsuario.estado = true;
                    context.Add(nuevoUsuario);
                    await context.SaveChangesAsync();
                    return View("..\\Login\\login");
                }
            }
            return Content("<a> Algo salio mal :/ </a>");
        }
    }
}
