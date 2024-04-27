using Microsoft.AspNetCore.Mvc;

using ModuloMesero.Models;

namespace ModuloMesero.Controllers
{
    public class ListaCuentaController : Controller
    {
        private readonly DulceSaborContext _DulceSaborContext;
        public ListaCuentaController(DulceSaborContext DulceSaborContext)
        {

            _DulceSaborContext = DulceSaborContext;


        }

        public IActionResult Index()
        {
            var listacuentas = (from c in _DulceSaborContext.Cuenta
                                join m in _DulceSaborContext.mesas on c.Id_mesa equals m.id_mesa
                                select new
                                {
                                    nombre = c.Nombre,
                                    idcuenta = c.Id_cuenta,
                                    nombremesa = m.nombre_mesa,
                                    m.id_mesa
                                }).ToList();
            ViewData["listcuenta"] = listacuentas;


            return View();

        }
        
    }
}
