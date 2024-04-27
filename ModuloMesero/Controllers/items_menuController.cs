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
        public IActionResult Index(string tipoPlato, int id_mesa)
        {

            ViewData["id"] = id_mesa;
            if (tipoPlato == "Entradas")
            {
                var listadomenu = (from m in _DulceSaborContext.items_menu
                                   join c in _DulceSaborContext.categorias on m.id_categoria equals c.id_categoria
                                   where c.categoria == "Entradas"
                                   select new
                                   {
                                       m.id_item_menu,
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
                                       m.id_item_menu,
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
                                       m.id_item_menu,
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
                                       m.id_item_menu,
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

        public IActionResult Añadirpedido(int id_mesa, int id_item_menu, int Cantidad, string? Comentario) 
        {
            var Cuenta = _DulceSaborContext.Cuenta.FirstOrDefault(c => c.Id_mesa == id_mesa && c.Estado_cuenta == "Abierta");
            var Plato = _DulceSaborContext.items_menu.FirstOrDefault(m => m.id_item_menu == id_item_menu);
            var detalle = _DulceSaborContext.Detalle_Pedido.FirstOrDefault(d => d.Id_cuenta == Cuenta.Id_cuenta);

            Detalle_Pedido nuevoDetallePedido = new Detalle_Pedido();

            nuevoDetallePedido.Id_cuenta= Cuenta.Id_cuenta;
            nuevoDetallePedido.Id_plato= id_item_menu;
            nuevoDetallePedido.Cantidad = Cantidad;
            nuevoDetallePedido.Estado = "Solicitado";
            nuevoDetallePedido.Tipo_Plato = "M";
            nuevoDetallePedido.Precio = (decimal)Plato.precio;
            _DulceSaborContext.Add(nuevoDetallePedido);
            _DulceSaborContext.SaveChanges();


            Comentarios nuevocomentario = new Comentarios();
            nuevocomentario.id_detallepedido = detalle.Id_DetalleCuenta;
            nuevocomentario.Comentario = Comentario;
            _DulceSaborContext.Add(nuevocomentario);
            _DulceSaborContext.SaveChanges();

            return RedirectToAction("Index", "Detalle_Pedido", new { id_mesa = id_mesa });
        }
        
    }
}
