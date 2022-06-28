using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ventasonline.Domain.Entities;

namespace ventasonline.Infrastructure.Persistence.Configurations;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Nombre)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(p => p.Descripcion)
            .HasMaxLength(1024)
            .IsRequired();

        builder.Property(p => p.Foto)
            .HasMaxLength(1024)
            .IsRequired();

        builder.HasMany(p => p.Precios)
            .WithOne()
            .HasForeignKey(p => p.ProductoId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.Categorias)
            .WithOne()
            .HasForeignKey(pc => pc.ProductoId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

    }
}
