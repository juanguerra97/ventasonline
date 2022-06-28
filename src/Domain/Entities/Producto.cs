
namespace ventasonline.Domain.Entities;

public class Producto : AuditableEntity
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Foto { get; set; }

    public List<Precio> Precios { get; set; }
    public List<ProductoCategoria> Categorias { get; set; }
}
