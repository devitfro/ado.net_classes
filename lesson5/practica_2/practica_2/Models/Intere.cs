using System;
using System.Collections.Generic;

namespace practica_2.Models;

public partial class Intere
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UsersIntere> UsersInteres { get; set; } = new List<UsersIntere>();
}
