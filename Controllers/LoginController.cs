using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Login(string email, string contrasena)
        {
            var usuarioEncontrado = await _context.usuarios
                .FirstOrDefaultAsync(u => u.email == email);

            if (usuarioEncontrado != null && usuarioEncontrado.CheckPassword(contrasena))
            {
                HttpContext.Session.SetString("UserId", usuarioEncontrado.id_usuario.ToString());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
        }
    }


    }
    //}
