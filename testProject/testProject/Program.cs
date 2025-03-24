using testProject.Models;

namespace testProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            using (var context = new MyDbContext())
            {
                var categories = context.Categories    
                                        .ToList();

                var c = new Category() { Name = "tablet" };
                context.Categories.Add(c);
                context.SaveChanges();

                foreach (var category in categories)
                {
                    Console.WriteLine($"ID: {category.Id}, Name: {category.Name}");
                }
            }
            Console.WriteLine("END OF PROGRAM!");
        }
    }
}
