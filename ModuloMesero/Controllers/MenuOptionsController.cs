using Microsoft.AspNetCore.Mvc;

namespace ModuloMesero.Controllers
{
    public class MenuOptionsController : Controller
    {
        public IActionResult Index(int id_mesa)
        {
            ViewData["id"] = id_mesa;
            return View();
        }
    }
}
