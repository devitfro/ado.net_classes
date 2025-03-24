using System;
using System.Collections.Generic;

namespace testProject.Models;

public partial class Review
{
    public int Id { get; set; }

    public string? Text { get; set; }

    public virtual ICollection<Product> IdProducts { get; set; } = new List<Product>();
}
