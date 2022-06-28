
namespace ventasonline.Domain.Entities;
public class Categoria : AuditableEntity
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public List<ProductoCategoria> Productos;
}
