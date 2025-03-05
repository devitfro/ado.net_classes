using System;
using System.Collections.Generic;

namespace practica_2.Models;

public partial class UsersPlace
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CountryId { get; set; }

    public int RegionId { get; set; }

    public int CityId { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual Country Country { get; set; } = null!;

    public virtual Region Region { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
