using System;
using System.Collections.Generic;

namespace practica.Models;

public partial class SCard
{
    public int Id { get; set; }

    public int IdStudent { get; set; }

    public int IdBook { get; set; }

    public string? DateOut { get; set; }

    public string? DateIn { get; set; }

    public int IdLibrarian { get; set; }

    public virtual Book IdBookNavigation { get; set; } = null!;

    public virtual Librarian IdLibrarianNavigation { get; set; } = null!;

    public virtual Student IdStudentNavigation { get; set; } = null!;
}
