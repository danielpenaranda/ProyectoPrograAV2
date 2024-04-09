using Microsoft.AspNetCore.Mvc;
using ProyectoPrograAV2.Models;

public class TiendaController : Controller
{
    private readonly DemoContext _context;

    public TiendaController(DemoContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var productos = _context.productos.ToList();
        return View(productos);
    }
}
