using System;
using System.Collections.Generic;

namespace bthuchanh8.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Images { get; set; }

    public double Price { get; set; }

    public int Stock { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}
