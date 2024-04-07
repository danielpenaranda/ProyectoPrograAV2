using Microsoft.AspNetCore.Mvc;
using ProyectoPrograAV2.Models;

public class TiendaController : Controller
{
    private readonly ProyectoTiendaG6Context _context;

    public TiendaController(ProyectoTiendaG6Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var productos = _context.productos.ToList();
        return View(productos);
    }
}
