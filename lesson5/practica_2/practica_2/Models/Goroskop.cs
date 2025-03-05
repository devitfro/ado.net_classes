using System;
using System.Collections.Generic;

namespace practica_2.Models;

public partial class Goroskop
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Ot { get; set; } = null!;

    public string Do { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
