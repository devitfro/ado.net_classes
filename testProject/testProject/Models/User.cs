using System;
using System.Collections.Generic;

namespace testProject.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; } // add field Age

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
