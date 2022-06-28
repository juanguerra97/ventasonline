
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ventasonline.Domain.Entities;

namespace ventasonline.Infrastructure.Persistence.Configurations;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Nombre)
            .HasMaxLength(256)
            .IsRequired();

        builder.HasMany(c => c.Productos)
            .WithOne()
            .HasForeignKey(pc => pc.CategoriaId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
