using System;
using System.Collections.Generic;

namespace practica_2.Models;

public partial class UsersLifetarget
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int LifetargetsId { get; set; }

    public virtual Lifetarget Lifetargets { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
