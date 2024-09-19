using System;
using System.Collections.Generic;

namespace ADO2.Models;

public partial class Shipper
{
    public int ShipperId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual ICollection<Salesorder> Salesorders { get; set; } = new List<Salesorder>();
}
