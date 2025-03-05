using System;
using System.Collections.Generic;

namespace practica_2.Models;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Flag { get; set; } = null!;

    public virtual ICollection<Region> Regions { get; set; } = new List<Region>();

    public virtual ICollection<UsersPlace> UsersPlaces { get; set; } = new List<UsersPlace>();
}
