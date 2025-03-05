using System;
using System.Collections.Generic;

namespace practica.Models;

public partial class Publishment
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
