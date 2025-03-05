using System;
using System.Collections.Generic;

namespace practica_2.Models;

public partial class UsersDatingtarget
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? DatingtargetId { get; set; }

    public virtual Datingtarget? Datingtarget { get; set; }

    public virtual User? User { get; set; }
}
