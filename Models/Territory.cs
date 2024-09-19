﻿using System;
using System.Collections.Generic;

namespace ADO2.Models;

public partial class Territory
{
    public string TerritoryId { get; set; } = null!;

    public string Territorydescription { get; set; } = null!;

    public int RegionId { get; set; }

    public virtual Region Region { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
