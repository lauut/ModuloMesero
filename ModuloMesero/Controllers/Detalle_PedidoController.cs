using Microsoft.AspNetCore.Mvc;
using ModuloMesero.Models;

namespace ModuloMesero.Controllers
{
    public class Detalle_PedidoController : Controller
    {
        private readonly DulceSaborContext _context;

        public Detalle_PedidoController(DulceSaborContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id_mesa)
        {
           var Cuenta = _context.Cuenta.FirstOrDefault(c => c.Id_mesa == id_mesa && c.Estado_cuenta== "Abierta");
           ViewData["Cuenta"] = Cuenta;
           
            return View(Cuenta);
        }
    }
}
