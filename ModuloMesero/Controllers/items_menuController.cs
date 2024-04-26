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
        public IActionResult Index()
        {
            var listadomenu = (from m in _DulceSaborContext.items_menu
                               join c in _DulceSaborContext.categorias on m.id_categoria equals c.id_categoria
                               select new
                               {
                                   m.nombre,
                                   m.descripcion,
                                   m.precio,
                                   m.imagen,
                                   c.id_categoria
                               }).ToList();
            ViewData["listmenu"] = listadomenu;

            // Obtener el ID de la primera categoría
            int categoriaId = listadomenu.FirstOrDefault()?.id_categoria ?? 0;

            // Asignar la vista de datos según la categoría
            switch (categoriaId)
            {
                case 1:
                    ViewData["Entradas"] = ObtenerEntradas();
                    break;
                case 2:
                    ViewData["PlatosFuertes"] = ObtenerPlatosFuertes();
                    break;
                case 3:
                    ViewData["Bebidas"] = ObtenerBebidas();
                    break;
                case 4:
                    ViewData["Postres"] = ObtenerPostres();
                    break;
                default:
                    // Manejo para categoría no válida
                    break;
            }

            return View();
        }
        private object ObtenerEntradas()
        {
            var listaentradas = (from m in _DulceSaborContext.items_menu
                               join c in _DulceSaborContext.categorias on m.id_categoria equals c.id_categoria
                               select new
                               {
                                   m.nombre,
                                   m.descripcion,
                                   m.precio,
                                   m.imagen,
                               }).ToList();
            ViewData["Entradas"] = listaentradas;
            return View();

        }

        private object ObtenerPlatosFuertes()
        {
            var listaplatofuerte = (from m in _DulceSaborContext.items_menu
                                 join c in _DulceSaborContext.categorias on m.id_categoria equals c.id_categoria
                                 select new
                                 {
                                     m.nombre,
                                     m.descripcion,
                                     m.precio,
                                     m.imagen,
                                 }).ToList();
            ViewData["PlatosFuertes"] = listaplatofuerte;
            return View();
        }

        private object ObtenerBebidas()
        {
            var listabebida = (from m in _DulceSaborContext.items_menu
                                    join c in _DulceSaborContext.categorias on m.id_categoria equals c.id_categoria
                                    select new
                                    {
                                        m.nombre,
                                        m.descripcion,
                                        m.precio,
                                        m.imagen,
                                    }).ToList();
            ViewData["Bebidas"] = listabebida;
            return View();

        }

        private object ObtenerPostres()
        {
            var listapostres = (from m in _DulceSaborContext.items_menu
                                    join c in _DulceSaborContext.categorias on m.id_categoria equals c.id_categoria
                                    select new
                                    {
                                        m.nombre,
                                        m.descripcion,
                                        m.precio,
                                        m.imagen,
                                    }).ToList();
            ViewData["Postres"] = listapostres;
            return View();
        }
    }
}
