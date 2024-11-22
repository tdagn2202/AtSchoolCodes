﻿using System;
using System.Collections.Generic;

namespace BlazorStaff.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime StartingDate { get; set; }

    public int? GenderId { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Gender? Gender { get; set; }
}
