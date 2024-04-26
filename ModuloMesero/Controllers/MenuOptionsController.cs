using Microsoft.AspNetCore.Mvc;

namespace ModuloMesero.Controllers
{
    public class MenuOptionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
