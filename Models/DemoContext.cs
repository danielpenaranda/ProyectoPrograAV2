using Microsoft.EntityFrameworkCore;

namespace ProyectoPrograAV2.Models
{
    public class DemoContext : DbContext
    {
        public DemoContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=proyecto_tienda_G6;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        public DbSet<Usuario> usuarios { get; set; }

        //public DbSet<Game> Games { get; set; }



    }
}
