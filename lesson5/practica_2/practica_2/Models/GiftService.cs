using System;
using System.Collections.Generic;

namespace practica_2.Models;

public partial class GiftService
{
    public int Id { get; set; }

    public int IdFrom { get; set; }

    public int IdTo { get; set; }

    public string Message { get; set; } = null!;

    public DateTime TimeCode { get; set; }

    public virtual User IdFromNavigation { get; set; } = null!;

    public virtual User IdToNavigation { get; set; } = null!;
}
