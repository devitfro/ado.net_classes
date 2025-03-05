using System;
using System.Collections.Generic;

namespace practica.Models;

public partial class Theme
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
