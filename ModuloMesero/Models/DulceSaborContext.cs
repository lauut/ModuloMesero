using Microsoft.EntityFrameworkCore;
namespace ModuloMesero.Models
{
    public class DulceSaborContext : DbContext
    {
        public DulceSaborContext(DbContextOptions options) : base(options) { }
    }
}
