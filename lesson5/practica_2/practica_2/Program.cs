using practica_2.Models;

namespace practica_2;

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
            Console.WriteLine("Hello, World!");

            using (var context = new MyDbContext())
            {
                var users = context.Users
                                        .Where(u => u.Age >= 18 && u.Age <= 60 && u.Sex == 1)                                        
                                        .ToList();
            
            foreach (var u in users)
            {
                Console.WriteLine($"ID: {u.Id}, Name: {u.Nick}, Age:{u.Age}, Gender: {u.Sex}");
            }
        }
            Console.WriteLine("END OF PROGRAM!");
        }
    }
