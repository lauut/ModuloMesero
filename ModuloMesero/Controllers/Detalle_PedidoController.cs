using Microsoft.AspNetCore.Mvc;

namespace ModuloMesero.Controllers
{
    public class Detalle_PedidoController : Controller
    {
        public IActionResult Index(int idCuenta)
        {
            return View();
        }
    }
}
