using System;
using System.Collections.Generic;

namespace ADO2.Models;

public partial class Customerdemographic
{
    public int CustomerTypeId { get; set; }

    public string? CustomerDesc { get; set; }

    public virtual ICollection<Customer> Custs { get; set; } = new List<Customer>();
}
