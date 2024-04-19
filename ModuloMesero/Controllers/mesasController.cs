using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModuloMesero.Models;

namespace ModuloMesero.Controllers
{
    public class mesasController : Controller
    {
        private readonly DulceSaborContext _dulceSaborDbContext;

        public mesasController(DulceSaborContext DulceSaborDbContext)
        {
            _dulceSaborDbContext = DulceSaborDbContext;
        }
        public IActionResult Index()
        {
        //    var ListaDeMesas = (from m in _dulceSaborDbContext.mesas select m).ToList();

        //    ViewData["ListadoDeMesas"] = new SelectList(ListaDeMesas, "id_mesa", "cantidad_personas", "id_estado", "nombre_mesa");

            return View();
        }
    }
}
