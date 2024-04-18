using Microsoft.AspNetCore.Mvc;

namespace ModuloMesero.Controllers
{
    public class mesasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
