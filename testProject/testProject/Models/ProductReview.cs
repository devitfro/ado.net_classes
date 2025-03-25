namespace testProject.Models;

public partial class ProductReview
{
    public int IdProduct { get; set; }
    public Product Product { get; set; }

    public int IdReview { get; set; }
    public Review Review { get; set; }
}
