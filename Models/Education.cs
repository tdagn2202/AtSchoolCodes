using System;
using System.Collections.Generic;

namespace EmployeeInfo.Models;

public partial class Education
{
    public int EduId { get; set; }

    public string? EduName { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
