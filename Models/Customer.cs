using System;
using System.Collections.Generic;

namespace ADO2.Models;

public partial class Customer
{
    public int CustId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? ContactName { get; set; }

    public string? ContactTitle { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Region { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string? Phone { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public string? Fax { get; set; }

    public virtual ICollection<Salesorder> Salesorders { get; set; } = new List<Salesorder>();

    public virtual ICollection<Customerdemographic> CustomerTypes { get; set; } = new List<Customerdemographic>();
}
