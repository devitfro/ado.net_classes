using System;
using System.Collections.Generic;

namespace practica_2.Models;

public partial class UsersMole
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? MolesId { get; set; }

    public virtual Mole? Moles { get; set; }

    public virtual User? User { get; set; }
}
