using System;
using System.Collections.Generic;

namespace Lab10.Models;

public partial class ProductDetail
{
    public int ProductId { get; set; }

    public short? UnitsInStock { get; set; }

    public decimal? UnitPrice { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? ContactTitle { get; set; }
}
