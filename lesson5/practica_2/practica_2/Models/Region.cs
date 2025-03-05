using System;
using System.Collections.Generic;

namespace practica_2.Models;

public partial class Region
{
    public int Id { get; set; }

    public int IdCountry { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country IdCountryNavigation { get; set; } = null!;

    public virtual ICollection<UsersPlace> UsersPlaces { get; set; } = new List<UsersPlace>();
}
