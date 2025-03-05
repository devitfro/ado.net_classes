using System;
using System.Collections.Generic;

namespace practica_2.Models;

public partial class UsersIntere
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? InteresId { get; set; }

    public virtual Intere? Interes { get; set; }

    public virtual User? User { get; set; }
}
