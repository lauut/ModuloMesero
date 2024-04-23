using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModuloMesero.Models;

namespace ModuloMesero.Controllers
{
    public class CuentaController : Controller
    {

        private readonly DulceSaborContext _context;

        public CuentaController(DulceSaborContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id_mesa)
        {
            if (id_mesa == null)
            {
                return NotFound();
            }

            var mesa = await _context.mesas.FindAsync(id_mesa);
            ViewData["mesaseleccionada"] = mesa;
            if (mesa == null)
            {
                return NotFound();
            }
            return View(mesa);
        }

        public IActionResult CrearCuenta(int id_mesa,String nombre, int cantidadpersonas)
        {
            var mesaExistente = _context.mesas.FirstOrDefault(m => m.id_mesa == id_mesa);

            if (mesaExistente == null)
            {
                return NotFound();
            }

            mesaExistente.id_estado = 2;
        

            // Guarda los cambios en la base de datos
            _context.SaveChanges();



            Cuenta nuevacuenta = new Cuenta();

            nuevacuenta.Id_mesa = id_mesa;
            nuevacuenta.Nombre = nombre;
            nuevacuenta.Cantidad_Personas = cantidadpersonas;
            nuevacuenta.Estado_cuenta = "Abierta";
            nuevacuenta.Fecha_Hora = DateTime.Now;


            _context.Add(nuevacuenta);
            _context.SaveChanges();

            int id_cuenta = nuevacuenta.Id_cuenta;
            return RedirectToAction("Index","Detalle_Pedido", new { idCuenta=id_cuenta });
        }   
    }
}
