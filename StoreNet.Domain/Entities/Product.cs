using System;
using System.Collections.Generic;

namespace StoreNet.Domain.Entities;

public partial class Product : BaseEntity<int>
{
    public string Barcode { get; set; } = null!;

    public string? Description { get; set; }

    public byte[]? Image { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }
}
