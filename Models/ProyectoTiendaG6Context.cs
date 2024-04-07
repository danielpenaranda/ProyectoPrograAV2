using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoPrograAV2.Models;

public partial class ProyectoTiendaG6Context : DbContext
{
    public ProyectoTiendaG6Context()
    {
    }

    public ProyectoTiendaG6Context(DbContextOptions<ProyectoTiendaG6Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=LAPTOP-AIAP8O34\\SQLEXPRESS;database=proyecto_tienda_G6;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.id_producto).HasName("PK__producto__FF341C0DA76AEBD4");

            entity.ToTable("productos");

            entity.Property(e => e.id_producto).HasColumnName("id_producto");
            entity.Property(e => e.cantidadProductos).HasColumnName("cantidadProductos");
            entity.Property(e => e.descripcion)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.descuento)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("descuento");
            entity.Property(e => e.estado).HasColumnName("estado");
            entity.Property(e => e.fechaPublicacion).HasColumnName("fechaPublicacion");
            entity.Property(e => e.imagen)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("imagen");
            entity.Property(e => e.iva)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("iva");
            entity.Property(e => e.nombreProducto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombreProducto");
            entity.Property(e => e.precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
