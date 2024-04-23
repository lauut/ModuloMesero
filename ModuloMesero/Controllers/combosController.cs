using Microsoft.AspNetCore.Mvc;
using ModuloMesero.Models;

namespace ModuloMesero.Controllers
{
    public class combosController : Controller
    {

        private readonly DulceSaborContext _DulceSaborContext;
        public combosController(DulceSaborContext DulceSaborContext)
        {

            _DulceSaborContext = DulceSaborContext;


        }
        public IActionResult Index()
        {
            
            var listacombos = (from c in _DulceSaborContext.combos
                               join u in _DulceSaborContext.items_combo on c.id_combo equals u.id_combo
                               select new
                               {
                                   
                                   descripcion = c.descripcion,
                                   precio = c.precio

                               }).ToList();
            ViewData["listcombo"] = listacombos;


            return View();
        }
    }
}
