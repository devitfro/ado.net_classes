using System;
using System.Collections.Generic;

namespace repo.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
