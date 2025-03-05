using System;
using System.Collections.Generic;

namespace practica_2.Models;

public partial class UsersLanguage
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? LanguagesId { get; set; }

    public virtual Language? Languages { get; set; }

    public virtual User? User { get; set; }
}
