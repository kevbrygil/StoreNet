using System;
using System.Collections.Generic;

namespace StoreNet.Domain.Entities;

public partial class Store : BaseEntity<int>
{
    public string Branch { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<ProductStore> ProductStores { get; set; } = new List<ProductStore>();
}
