using Microsoft.EntityFrameworkCore;
using OperacionTupper3._0.Models;

namespace OperacionTupper3._0.Data;

public partial class MiDbContext : DbContext
{
    public MiDbContext()
    {
    }

    public MiDbContext(DbContextOptions<MiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ingredientes> Ingredientes { get; set; }

    public virtual DbSet<Platos> Platos { get; set; }

    public virtual DbSet<PlatoIngredientes> PlatoIngredientes { get; set; }
    public virtual DbSet<TipoIngrediente> TipoIngrediente { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=OperacionTupper;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlatoIngredientes>(entity =>
        {
            entity.HasKey(e => new { e.Id_Plato, e.Id_Ingrediente });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}