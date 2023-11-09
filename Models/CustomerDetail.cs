using System;
using System.Collections.Generic;

namespace Lab10.Models;

public partial class CustomerDetail
{
    public string CustomerId { get; set; } = null!;

    public string? ContactName { get; set; }

    public string? ContactTitle { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public string? Phone { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public DateTime? RequiredDate { get; set; }
}
