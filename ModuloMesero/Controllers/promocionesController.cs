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

        public IActionResult Index(int id_mesa)
        {
            ViewData["id"] = id_mesa;
            var listapromociones = (from p in _DulceSaborContext.promociones
                                    join u in _DulceSaborContext.items_promo on p.id_promo equals u.id_promo
                                    select new
                                    {
                                        p.id_promo,
                                        nombre=p.nombre,
                                        descripcion=p.descripcion,
                                        precio = p.precio,
                                        fechainicio=p.fecha_inicio,
                                        fechafin= p.fecha_final

                                    }).ToList();
            ViewData["listprom"] = listapromociones;











            return View();
        }

        public IActionResult Añadirpedido(int id_mesa, int id_promo, int Cantidad, string? Comentario)
        {
            var Cuenta = _DulceSaborContext.Cuenta.FirstOrDefault(c => c.Id_mesa == id_mesa && c.Estado_cuenta == "Abierta");
            var Plato = _DulceSaborContext.promociones.FirstOrDefault(m => m.id_promo == id_promo);
            var detalle = _DulceSaborContext.Detalle_Pedido.FirstOrDefault(d => d.Id_cuenta == Cuenta.Id_cuenta);

            Detalle_Pedido nuevoDetallePedido = new Detalle_Pedido();

            nuevoDetallePedido.Id_cuenta = Cuenta.Id_cuenta;
            nuevoDetallePedido.Id_plato = id_promo;
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
