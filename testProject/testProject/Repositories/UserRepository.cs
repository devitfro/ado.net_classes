using Microsoft.EntityFrameworkCore;
using testProject.Models;

namespace testProject.Repositories
{
    public class UserRepository
    {
        public void Add(User user)
        {
            using var context = new ApplicationDbContext();
            context.Users?.Add(user);
            context.SaveChanges();
            Console.WriteLine($"User {user.Name} added!");
        }

        public List<User> GetAll()
        {
            using var context = new ApplicationDbContext();
            return context.Users?.Include(u => u.Orders).ToList();
        }

        public User? GetById(int id)
        {
            using var context = new ApplicationDbContext();
            return context.Users?.Include(u => u.Orders).FirstOrDefault(u => u.Id == id);
        }

        public void Update(User user)
        {
            using var context = new ApplicationDbContext();
            context.Users?.Update(user);
            context.SaveChanges();
            Console.WriteLine($"User {user.Name} updated!");
        }

        public void Delete(int id)
        {
            using var context = new ApplicationDbContext();
            var user = context.Users?.Find(id);
            if (user == null) return;
            context.Users.Remove(user);
            context.SaveChanges();
            Console.WriteLine($"User {user.Name} deleted!");
        }
    }
}
