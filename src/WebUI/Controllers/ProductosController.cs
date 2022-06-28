using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ventasonline.Application.Common.Interfaces;
using ventasonline.Domain.Entities;

namespace ventasonline.WebUI.Controllers;

[AllowAnonymous]
public class ProductosController : ApiControllerBase
{

    private readonly IApplicationDbContext _context;

    public ProductosController(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<List<Producto>>> GetProductos()
    {
        return await _context.Producto.Include(p => p.Precios).Include(p => p.Categorias).ToListAsync();
    }
}
