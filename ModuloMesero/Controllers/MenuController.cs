using Microsoft.AspNetCore.Mvc;

namespace ModuloMesero.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
