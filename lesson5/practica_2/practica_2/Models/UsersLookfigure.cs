using System;
using System.Collections.Generic;

namespace practica_2.Models;

public partial class UsersLookfigure
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? FigureId { get; set; }

    public virtual Figure? Figure { get; set; }

    public virtual User? User { get; set; }
}
