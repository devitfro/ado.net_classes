using System;
using System.Collections.Generic;

namespace practica.Models;

public partial class Book
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Pages { get; set; }

    public int YearPress { get; set; }

    public int IdTheme { get; set; }

    public int IdCategory { get; set; }

    public int IdAuthor { get; set; }

    public int IdPublishment { get; set; }

    public string? Comment { get; set; }

    public int Quantity { get; set; }

    public virtual Author IdAuthorNavigation { get; set; } = null!;

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual Publishment IdPublishmentNavigation { get; set; } = null!;

    public virtual Theme IdThemeNavigation { get; set; } = null!;

    public virtual ICollection<SCard> SCards { get; set; } = new List<SCard>();

    public virtual ICollection<TCard> TCards { get; set; } = new List<TCard>();
}
