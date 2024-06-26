﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPrograAV2.Models;

namespace ProyectoPrograAV2.Controllers
{
    public class LoginController : Controller
    {
        private readonly DemoContext _context;

        public LoginController(DemoContext context)
        {
            _context = context;
        }

        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string email, string contrasena)
        {
            var usuarioEncontrado = await _context.usuarios
                .FirstOrDefaultAsync(u => u.email == email && u.contrasena == contrasena);

            if (usuarioEncontrado != null)
            {
                return RedirectToAction("Index", "Tienda"); 
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
        }

    }


}
  
