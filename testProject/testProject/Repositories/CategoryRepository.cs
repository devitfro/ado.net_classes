using Microsoft.EntityFrameworkCore;
using testProject.Models;

namespace testProject.Repositories
{
    public class CategoryRepository
    {
        public void Add(Category category)
        {
            using var context = new ApplicationDbContext();
            context.Categories?.Add(category);
            context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            using var context = new ApplicationDbContext();
            return context.Categories?.Include(c => c.Products).ToList();
        }

        public Category? GetById(int id)
        {
            using var context = new ApplicationDbContext();
            return context.Categories?.Include(c => c.Products).FirstOrDefault(c => c.Id == id);
        }

        public void Update(Category category)
        {
            using var context = new ApplicationDbContext();
            context.Categories?.Update(category);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            using var context = new ApplicationDbContext();
            var category = context.Categories?.Find(id);
            if (category == null) return;
            context.Categories.Remove(category);
            context.SaveChanges();
        }
    }
}
