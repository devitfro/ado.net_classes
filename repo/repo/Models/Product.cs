using System;
using System.Collections.Generic;

namespace repo.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdCategory { get; set; }

    public double Price { get; set; }

    public int Quantity { get; set; }

    public double PriceDelivery { get; set; }

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> IdReviews { get; set; } = new List<Review>();
}
