using Microsoft.EntityFrameworkCore;
using testProject.Models;

namespace testProject
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=TestProject;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductReview>()
                .HasKey(pr => new { pr.IdProduct, pr.IdReview });

            modelBuilder.Entity<ProductReview>()
                .HasOne(pr => pr.Product)
                .WithMany(p => p.ProductReviews)
                .HasForeignKey(pr => pr.IdProduct);

            modelBuilder.Entity<ProductReview>()
                .HasOne(pr => pr.Review)
                .WithMany(r => r.ProductReviews)
                .HasForeignKey(pr => pr.IdReview);
        }
    }
}
