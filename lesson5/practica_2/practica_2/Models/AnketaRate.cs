using System;
using System.Collections.Generic;

namespace practica_2.Models;

public partial class AnketaRate
{
    public int Id { get; set; }

    public int IdKto { get; set; }

    public int IdKogo { get; set; }

    public int Rating { get; set; }

    public virtual User IdKogoNavigation { get; set; } = null!;

    public virtual User IdKtoNavigation { get; set; } = null!;
}
