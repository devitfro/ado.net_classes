using System;
using System.Collections.Generic;

namespace practica_2.Models;

public partial class Language
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Predlog { get; set; } = null!;

    public virtual ICollection<UsersLanguage> UsersLanguages { get; set; } = new List<UsersLanguage>();
}
