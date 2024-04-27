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
        public IActionResult Index(int id_mesa)
        {
            ViewData["id"] = id_mesa;
            var listacombos = (from c in _DulceSaborContext.combos
                               join u in _DulceSaborContext.items_combo on c.id_combo equals u.id_combo
                               select new
                               {
                                   c.id_combo,
                                   descripcion = c.descripcion,
                                   precio = c.precio

                               }).ToList();
            ViewData["listcombo"] = listacombos;

            return View();

        }

        public IActionResult Añadirpedido(int id_mesa, int id_combo, int Cantidad, string? Comentario)
        {
            var Cuenta = _DulceSaborContext.Cuenta.FirstOrDefault(c => c.Id_mesa == id_mesa && c.Estado_cuenta == "Abierta");
            var Plato = _DulceSaborContext.combos.FirstOrDefault(m => m.id_combo == id_combo);
            var detalle = _DulceSaborContext.Detalle_Pedido.FirstOrDefault(d => d.Id_cuenta == Cuenta.Id_cuenta);

            Detalle_Pedido nuevoDetallePedido = new Detalle_Pedido();

            nuevoDetallePedido.Id_cuenta = Cuenta.Id_cuenta;
            nuevoDetallePedido.Id_plato = id_combo;
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
