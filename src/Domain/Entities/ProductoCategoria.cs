
namespace ventasonline.Domain.Entities;
public class ProductoCategoria : AuditableEntity
{
    public int ProductoId { get; set; }
    //public Producto Producto { get; set; }
    public int CategoriaId { get; set; }
    //public Categoria Categoria { get; set; }
}
