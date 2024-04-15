using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoPrograAV2.Models;

public partial class DemoContext : DbContext
{
    public DemoContext(DbContextOptions<DemoContext> options)
        : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-AIAP8O34\\SQLEXPRESS;database=proyecto_tienda_G6;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
    public DbSet<Usuario> usuarios { get; set; }
    public DbSet<Producto> productos { get; set; }
    public DbSet<Carrito> carrito { get; set; }
    public DbSet<Historial> historial { get; set; }


}