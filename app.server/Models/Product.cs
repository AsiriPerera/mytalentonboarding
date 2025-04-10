using System;
using System.Collections.Generic;

namespace app.server.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public double? Price { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
