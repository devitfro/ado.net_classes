using System;
using System.Collections.Generic;

namespace practica_2.Models;

public partial class Datingtarget
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UsersDatingtarget> UsersDatingtargets { get; set; } = new List<UsersDatingtarget>();
}
