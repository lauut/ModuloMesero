using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModuloMesero.Models;

namespace ModuloMesero.Controllers
{
    
    public class items_menuController : Controller
    {

        private readonly DulceSaborContext _DulceSaborContext;
        public items_menuController(DulceSaborContext DulceSaborContext)
        {

            _DulceSaborContext = DulceSaborContext;


        }
        public IActionResult Index(string tipoPlato)
        {
            if (tipoPlato == "Entradas")
            {
                var listadomenu = (from m in _DulceSaborContext.items_menu
                                   join c in _DulceSaborContext.categorias on m.id_categoria equals c.id_categoria
                                   where c.categoria == "Entradas"
                                   select new
                                   {
                                       m.nombre,
                                       m.descripcion,
                                       m.precio,
                                       m.imagen,
                                       c.categoria
                                   }).ToList();
                ViewData["listmenu"] = listadomenu;
                ViewData["categoria"] = "Entrada";
                return View();
            }
            else if (tipoPlato == "PlatoFuerte")
            {
                var listadomenu = (from m in _DulceSaborContext.items_menu
                                   join c in _DulceSaborContext.categorias on m.id_categoria equals c.id_categoria
                                   where c.categoria == "Plato fuerte"
                                   select new
                                   {
                                       m.nombre,
                                       m.descripcion,
                                       m.precio,
                                       m.imagen,
                                       c.categoria
                                   }).ToList();
                ViewData["listmenu"] = listadomenu;
                ViewData["categoria"] = "Plato Fuerte";
                return View();
            }
            else if (tipoPlato == "Postres")
            {
                var listadomenu = (from m in _DulceSaborContext.items_menu
                                   join c in _DulceSaborContext.categorias on m.id_categoria equals c.id_categoria
                                   where c.categoria == "Postres"
                                   select new
                                   {
                                       m.nombre,
                                       m.descripcion,
                                       m.precio,
                                       m.imagen,
                                       c.categoria
                                   }).ToList();
                ViewData["listmenu"] = listadomenu;
                ViewData["categoria"] = "Postres";
                return View();
            }
            else if (tipoPlato == "Bebidas")
            {
                var listadomenu = (from m in _DulceSaborContext.items_menu
                                   join c in _DulceSaborContext.categorias on m.id_categoria equals c.id_categoria
                                   where c.categoria == "Bebidas"
                                   select new
                                   {
                                       m.nombre,
                                       m.descripcion,
                                       m.precio,
                                       m.imagen,
                                       c.categoria
                                   }).ToList();
                ViewData["listmenu"] = listadomenu; 
                ViewData["categoria"] = "Bebidas";
                return View();
            }
            else
            {
                return NotFound(); 
            }
           
        }
        
    }
}
