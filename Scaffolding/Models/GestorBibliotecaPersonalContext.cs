using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Scaffolding.Models;

public partial class GestorBibliotecaPersonalContext : DbContext
{
    public GestorBibliotecaPersonalContext()
    {
    }

    public GestorBibliotecaPersonalContext(DbContextOptions<GestorBibliotecaPersonalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tabla> Tablas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:Connection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tabla>(entity =>
        {
            entity.HasKey(e => e.IdLibro);

            entity.ToTable("Tabla", "gbp_almacen");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
