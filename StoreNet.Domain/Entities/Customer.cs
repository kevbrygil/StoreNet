using System;
using System.Collections.Generic;

namespace StoreNet.Domain.Entities;

public partial class Customer : BaseEntity<int>
{ 
    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Address { get; set; } = null!;
}
