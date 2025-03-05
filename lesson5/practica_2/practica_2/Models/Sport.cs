using System;
using System.Collections.Generic;

namespace practica_2.Models;

public partial class Sport
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UsersSport> UsersSports { get; set; } = new List<UsersSport>();
}
