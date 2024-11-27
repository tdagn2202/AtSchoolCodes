using System;
using System.Collections.Generic;

namespace BookService.Model;

public partial class Bookstore
{
    public int BookNo { get; set; }

    public string BookName { get; set; } = null!;

    public string Publisher { get; set; } = null!;

    public int Quantity { get; set; }

    public double UnitPrice { get; set; }
}
