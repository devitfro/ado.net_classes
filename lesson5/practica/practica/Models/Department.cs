using System;
using System.Collections.Generic;

namespace practica.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
