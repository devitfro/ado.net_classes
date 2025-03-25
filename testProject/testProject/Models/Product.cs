using System;
using System.Collections.Generic;

namespace testProject.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdCategory { get; set; }

    public double Price { get; set; }

    public int Quantity { get; set; }

    public double PriceDelivery { get; set; }

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
}
