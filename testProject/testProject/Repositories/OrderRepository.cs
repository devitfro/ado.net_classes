using Microsoft.EntityFrameworkCore;
using testProject.Models;

namespace testProject.Repositories
{
    public class OrderRepository
    {
        public void Add(Order order)
        {
            using var context = new ApplicationDbContext();
            context.Orders?.Add(order);
            context.SaveChanges();
        }

        public List<Order> GetAll()
        {
            using var context = new ApplicationDbContext();
            return context.Orders?.Include(o => o.User).Include(o => o.Product).ToList();
        }

        public Order? GetById(int id)
        {
            using var context = new ApplicationDbContext();
            return context.Orders?.Include(o => o.User).Include(o => o.Product).FirstOrDefault(o => o.Id == id);
        }

        public void Update(Order order)
        {
            using var context = new ApplicationDbContext();
            context.Orders?.Update(order);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            using var context = new ApplicationDbContext();
            var order = context.Orders?.Find(id);
            if (order == null) return;
            context.Orders.Remove(order);
            context.SaveChanges();
        }
    }
}
