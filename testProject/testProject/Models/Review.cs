using System;
using System.Collections.Generic;

namespace testProject.Models;

public partial class Review
{
    public int Id { get; set; }

    public string? Text { get; set; }

    public ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

}
