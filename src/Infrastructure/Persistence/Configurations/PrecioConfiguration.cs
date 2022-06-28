
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ventasonline.Domain.Entities;

namespace ventasonline.Infrastructure.Persistence.Configurations;

public class PrecioConfiguration : IEntityTypeConfiguration<Precio>
{
    public void Configure(EntityTypeBuilder<Precio> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Descripcion)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(p => p.ValorPrecio)
            .IsRequired();

    }
}
