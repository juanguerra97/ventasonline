using ventasonline.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ventasonline.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get;  }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Producto> Producto { get; }

    DbSet<Precio> Precio { get; }

    DbSet<Categoria> Categoria { get; }

    DbSet<ProductoCategoria> ProductoCategoria { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
