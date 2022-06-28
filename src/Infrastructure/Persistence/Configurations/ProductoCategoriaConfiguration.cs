
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ventasonline.Domain.Entities;

namespace ventasonline.Infrastructure.Persistence.Configurations;

public class ProductoCategoriaConfiguration : IEntityTypeConfiguration<ProductoCategoria>
{
    public void Configure(EntityTypeBuilder<ProductoCategoria> builder)
    {
        builder.HasKey(p => new { p.ProductoId, p.CategoriaId });


    }
}
