using Microsoft.EntityFrameworkCore;
namespace ModuloMesero.Models
{
    public class DulceSaborContext : DbContext
    {
        public DulceSaborContext(DbContextOptions options) : base(options) 
        { 
            
        }

        public DbSet<mesas> mesas { get; set; }
        public DbSet<estados> estados { get; set; }
        public DbSet<Comentarios> comentarios { get; set; }
        public DbSet<Cuenta> cuentas { get; set; }
        public DbSet<Detalle_Pedido> detalle_Pedidos { get; set; }
    }
}
