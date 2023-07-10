namespace StoreNet.Domain.Entities;

public partial class ProductStore : BaseAuditableEntity<int>
{
    public int ProductId { get; set; }

    public int StoreId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
