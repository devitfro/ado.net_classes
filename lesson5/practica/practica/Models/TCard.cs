using System;
using System.Collections.Generic;

namespace practica.Models;

public partial class TCard
{
    public int Id { get; set; }

    public int? IdTeacher { get; set; }

    public int? IdBook { get; set; }

    public string? DateOut { get; set; }

    public string? DateIn { get; set; }

    public int? IdLibrarian { get; set; }

    public virtual Book? IdBookNavigation { get; set; }

    public virtual Librarian? IdLibrarianNavigation { get; set; }

    public virtual Teacher? IdTeacherNavigation { get; set; }
}
