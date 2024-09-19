using System;
using System.Collections.Generic;

namespace ADO2.Models;

public partial class Region
{
    public int RegionId { get; set; }

    public string Regiondescription { get; set; } = null!;

    public virtual ICollection<Territory> Territories { get; set; } = new List<Territory>();
}
