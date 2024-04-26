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

           var Detalle_Pedido = (from dp in _context.Detalle_Pedido
                                 where dp.Id_cuenta == Cuenta.Id_cuenta
                                 join p in _context.items_menu on dp.Id_plato equals p.id_item_menu
                                 select new
                                 {
                                     p.nombre,
                                     dp.Cantidad,
                                     dp.Precio,
                                     dp.Estado
                                 }
                                 ).ToList();


           ViewData["Detalle_Pedido"] = Detalle_Pedido;
           
           return View();

            
           
        }
    }
}
