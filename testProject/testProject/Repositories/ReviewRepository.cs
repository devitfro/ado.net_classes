using Microsoft.EntityFrameworkCore;
using testProject.Models;

namespace testProject
{

    internal partial class Program
    {
        public class ReviewRepository
        {
            public void Add(Review review)
            {
                using var context = new ApplicationDbContext();
                context.Reviews?.Add(review);
                context.SaveChanges();
            }

            public List<Review> GetAll()
            {
                using var context = new ApplicationDbContext();
                return context.Reviews?.Include(r => r.ProductReviews).ToList();
            }

            public Review? GetById(int id)
            {
                using var context = new ApplicationDbContext();
                return context.Reviews?.Include(r => r.ProductReviews).FirstOrDefault(r => r.Id == id);
            }

            public void Update(Review review)
            {
                using var context = new ApplicationDbContext();
                context.Reviews?.Update(review);
                context.SaveChanges();
            }

            public void Delete(int id)
            {
                using var context = new ApplicationDbContext();
                var review = context.Reviews?.Find(id);
                if (review == null) return;
                context.Reviews.Remove(review);
                context.SaveChanges();
            }
        }
    }
}
