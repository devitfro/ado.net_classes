using System;
using System.Collections.Generic;

namespace practica_2.Models;

public partial class Orientation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
