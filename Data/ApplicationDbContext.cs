using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoPrograAV2.Models;

namespace ProyectoPrograAV2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> usuarios { get; set; }
        public DbSet<Producto> productos { get; set; }
        public DbSet<Carrito> carrito { get; set; }
        public DbSet<Historial> historial { get; set; }

        // Anula el método OnModelCreating para evitar que Entity Framework configure las tablas de Identity
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Aquí puedes configurar tus relaciones y restricciones de tus modelos existentes si es necesario

            //modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");
            //modelBuilder.Entity<IdentityUser>().ToTable("AspNetUsers");
            //modelBuilder.Entity<Producto>().ToTable("productos");
            //modelBuilder.Entity<Carrito>().ToTable("carrito");
            //modelBuilder.Entity<Historial>().ToTable("historial");

            modelBuilder.Entity<Producto>()
               .Property(p => p.precio)
               .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Producto>()
                .Property(p => p.descuento)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Producto>()
                .Property(p => p.iva)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Historial>()
                .Property(h => h.pagos)
                .HasColumnType("decimal(18,2)");
        }
    }
}
