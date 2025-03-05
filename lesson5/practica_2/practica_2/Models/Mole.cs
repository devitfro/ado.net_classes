using System;
using System.Collections.Generic;

namespace practica_2.Models;

public partial class Mole
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UsersMole> UsersMoles { get; set; } = new List<UsersMole>();
}
