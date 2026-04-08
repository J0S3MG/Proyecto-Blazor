using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ejemplo_MudBlazor.Models;

namespace Ejemplo_MudBlazor.Data.Seeds;

public class ReunionSeed : IEntityTypeConfiguration<Reunion>
{
    public void Configure(EntityTypeBuilder<Reunion> builder)
    {
        builder.HasData(
            new(1, "Revisión de arquitectura: Implementación de patrón MVVM en el módulo de reuniones.", true),
            new(2, "Sincronización de equipo: Discusión sobre la migración de SQL Server a PostgreSQL.", false),
            new(3, "Capacitación técnica: Mejores prácticas para el uso de Dependency Injection en .NET 8.", false),
            new(4, "Daily meeting: Seguimiento de tareas del Proyecto Verano y despliegue en Railway.", true)
        );
    }
}