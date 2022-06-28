using ventasonline.Domain.Entities;
using ventasonline.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ventasonline.Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            //if (_context.Database.IsMySql())
            //{
            //    await _context.Database.MigrateAsync();
            //}
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {

        var administratorRole = new IdentityRole("Administrator");

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
        }


        if (!_context.Producto.Any())
        {
            var categoria1 = new Categoria
            {
                Nombre = "Cereales"
            };
            _context.Categoria.Add(categoria1);

            var categoria2 = new Categoria
            {
                Nombre = "Bebidas"
            };
            _context.Categoria.Add(categoria2);

            var categoria3 = new Categoria
            {
                Nombre = "Lacteos"
            };
            _context.Categoria.Add(categoria3);


            var producto1 = new Producto
            {
                Nombre = "Corn Flakes",
                Descripcion = "Cereal Corn Flakes de Kellogs 800gr",
                Foto = "https://walmartgt.vtexassets.com/arquivos/ids/261502-500-auto?v=637848670749530000&width=500&height=auto&aspect=true"
            };
            _context.Producto.Add(producto1);
            _context.ProductoCategoria.Add(new ProductoCategoria
            {
                CategoriaId = categoria1.Id,
                ProductoId = producto1.Id
            });
            _context.Precio.Add(new Precio
            {
                ProductoId = producto1.Id,
                Descripcion = "Unitario",
                ValorPrecio = 32.90M
            });
            _context.Precio.Add(new Precio
            {
                ProductoId = producto1.Id,
                Descripcion = "Liquidacion",
                ValorPrecio = 20.50M
            });

            var producto2 = new Producto
            {
                Nombre = "Nesquick",
                Descripcion = "Cereal NESTLE NESQUIK® Chocolate Cereal 720gr",
                Foto = "https://walmartgt.vtexassets.com/arquivos/ids/266313-500-auto?v=637868650436300000&width=500&height=auto&aspect=true"
            };
            _context.Producto.Add(producto2);
            _context.ProductoCategoria.Add(new ProductoCategoria
            {
                CategoriaId = categoria1.Id,
                ProductoId = producto2.Id
            });
            _context.Precio.Add(new Precio
            {
                ProductoId = producto2.Id,
                Descripcion = "Unitario",
                ValorPrecio = 31.35M
            });
            _context.Precio.Add(new Precio
            {
                ProductoId = producto2.Id,
                Descripcion = "OFERTA",
                ValorPrecio = 25.18M
            });

            var producto3 = new Producto
            {
                Nombre = "Jugo de Melocotón",
                Descripcion = "Nectar Del Monte Melocoton 330Ml",
                Foto = "https://walmartgt.vtexassets.com/arquivos/ids/182453-500-auto?v=637608440167670000&width=500&height=auto&aspect=true"
            };
            _context.Producto.Add(producto3);
            _context.ProductoCategoria.Add(new ProductoCategoria
            {
                CategoriaId = categoria2.Id,
                ProductoId = producto3.Id
            });
            _context.Precio.Add(new Precio
            {
                ProductoId = producto3.Id,
                Descripcion = "Unitario",
                ValorPrecio = 3.25M
            });

            var producto4 = new Producto
            {
                Nombre = "Coca-Cola",
                Descripcion = "Bebida Gaseosa Coca Cola Original 600Ml",
                Foto = "https://walmartgt.vtexassets.com/arquivos/ids/219208-500-auto?v=637716478767800000&width=500&height=auto&aspect=true"
            };
            _context.Producto.Add(producto4);
            _context.ProductoCategoria.Add(new ProductoCategoria
            {
                CategoriaId = categoria3.Id,
                ProductoId = producto4.Id
            });
            _context.Precio.Add(new Precio
            {
                ProductoId = producto4.Id,
                Descripcion = "Unitario",
                ValorPrecio = 7.25M
            });
            _context.Precio.Add(new Precio
            {
                ProductoId = producto4.Id,
                Descripcion = "Oferta",
                ValorPrecio = 6.30M
            });

            var producto5 = new Producto
            {
                Nombre = "Leche Dos Pinos",
                Descripcion = "Leche Dos Pinos Pinito Entera 1000ml",
                Foto = "https://walmartgt.vtexassets.com/arquivos/ids/250154-500-auto?v=637816917868100000&width=500&height=auto&aspect=true"
            };
            _context.Producto.Add(producto5);
            _context.ProductoCategoria.Add(new ProductoCategoria
            {
                CategoriaId = categoria3.Id,
                ProductoId = producto5.Id
            });
            _context.Precio.Add(new Precio
            {
                ProductoId = producto5.Id,
                Descripcion = "Unitario",
                ValorPrecio = 15.80M
            });
            _context.Precio.Add(new Precio
            {
                ProductoId = producto5.Id,
                Descripcion = "Mayoreo",
                ValorPrecio = 13.50M
            });
            await _context.SaveChangesAsync();
        }

    }
}