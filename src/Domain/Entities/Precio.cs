
namespace ventasonline.Domain.Entities;

public class Precio : AuditableEntity
{
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public string Descripcion { get; set; }
    public decimal ValorPrecio { get; set; }
}
