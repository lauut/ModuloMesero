using Microsoft.AspNetCore.Mvc;
using ModuloMesero.Models;

namespace ModuloMesero.Controllers
{
    public class promocionesController : Controller
    {

        private readonly DulceSaborContext _DulceSaborContext;
        public promocionesController(DulceSaborContext DulceSaborContext) {
            
            _DulceSaborContext = DulceSaborContext;

          
        }

        public IActionResult Index()
        {
            
            var listapromociones = (from p in _DulceSaborContext.promociones
                                    join u in _DulceSaborContext.items_promo on p.id_promo equals u.id_promo
                                    select new
                                    {
                                        nombre=p.nombre,
                                        descripcion=p.descripcion,
                                        precio = p.precio

                                    }).ToList();
            ViewData["listprom"] = listapromociones;











            return View();
        }
    }
}
