using System;
using System.Collections.Generic;

namespace testProject.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? IdUser { get; set; }

    public int? IdProduct { get; set; }

    // Navigation properties
    public User User { get; set; }

    public Product Product { get; set; }
}
