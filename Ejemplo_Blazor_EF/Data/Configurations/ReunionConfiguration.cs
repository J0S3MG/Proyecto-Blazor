using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ejemplo_Blazor_EF.Models;

namespace Ejemplo_Blazor_EF.Data.Configurations;

public class ReunionConfiguration : IEntityTypeConfiguration<Reunion>
{
    public void Configure(EntityTypeBuilder<Reunion> builder)
    {
        builder.ToTable("reunion");
        // PK.
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedOnAdd();
        // Descripcion.
        builder.Property(r => r.Desc).HasMaxLength(500);
        // ¿Virtual?.
        builder.Property(r => r.Virtual).HasDefaultValue(false);
    }
}