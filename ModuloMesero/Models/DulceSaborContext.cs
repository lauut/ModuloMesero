﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Detalle_Pedido> Detalle_Pedido { get; set; }
        public DbSet<promociones> promociones { get; set; }
        public DbSet<items_menu> items_menu { get; set; }
        public DbSet<items_promo> items_promo { get; set; }
        public DbSet<items_combo> items_combo { get; set; }
        public DbSet<combos> combos { get; set; }
        public DbSet<categorias> categorias { get; set; }
    }
}
