using System;
using System.Collections.Generic;

namespace practica_2.Models;

public partial class City
{
    public int Id { get; set; }

    public int IdRegion { get; set; }

    public string Name { get; set; } = null!;

    public virtual Region IdRegionNavigation { get; set; } = null!;

    public virtual ICollection<UsersPlace> UsersPlaces { get; set; } = new List<UsersPlace>();
}
