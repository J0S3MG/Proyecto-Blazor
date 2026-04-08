using Microsoft.EntityFrameworkCore;
using Ejemplo_MudBlazor.Models;
using Ejemplo_MudBlazor.Data.Configurations;
using Ejemplo_MudBlazor.Data.Seeds;

namespace Ejemplo_MudBlazor.Data;

public class ReunionContext: DbContext
{
    public DbSet<Reunion> Reuniones { get; set; } = null!;

    public ReunionContext(DbContextOptions<ReunionContext> options): base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ReunionConfiguration());
        modelBuilder.ApplyConfiguration(new ReunionSeed());
    }
}