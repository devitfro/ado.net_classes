using System;
using System.Collections.Generic;

namespace practica_2.Models;

public partial class Message
{
    public int Id { get; set; }

    public int? Status { get; set; }

    public int? IdFrom { get; set; }

    public int? IdTo { get; set; }

    public string? Mess { get; set; }

    public DateTime? DateSent { get; set; }

    public virtual User? IdFromNavigation { get; set; }

    public virtual User? IdToNavigation { get; set; }
}
