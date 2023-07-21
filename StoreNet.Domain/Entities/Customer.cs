namespace StoreNet.Domain.Entities;

public partial class Customer : BaseEntity<int>
{
    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
