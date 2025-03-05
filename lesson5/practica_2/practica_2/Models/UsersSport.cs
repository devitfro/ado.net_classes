using System;
using System.Collections.Generic;

namespace practica_2.Models;

public partial class UsersSport
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? SportId { get; set; }

    public virtual Sport? Sport { get; set; }

    public virtual User? User { get; set; }
}
