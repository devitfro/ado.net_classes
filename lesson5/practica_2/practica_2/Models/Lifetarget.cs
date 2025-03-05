using System;
using System.Collections.Generic;

namespace practica_2.Models;

public partial class Lifetarget
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UsersLifetarget> UsersLifetargets { get; set; } = new List<UsersLifetarget>();
}
