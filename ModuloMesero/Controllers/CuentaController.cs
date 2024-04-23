using Microsoft.AspNetCore.Mvc;

namespace ModuloMesero.Controllers
{
    public class CuentaController : Controller
    {
        public IActionResult Index(int? id_mesa)
        {
            return View();
        }
    }
}
