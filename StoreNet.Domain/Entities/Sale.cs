﻿using System;
using System.Collections.Generic;

namespace StoreNet.Domain.Entities;

public partial class Sale : BaseAuditableEntity<int>
{
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Total { get; set; }
    public virtual Customer Customer { get; set; } = null!;
    public virtual Product Product { get; set; } = null!;
}
