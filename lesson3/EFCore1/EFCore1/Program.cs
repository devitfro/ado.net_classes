using Microsoft.EntityFrameworkCore;
using EFCore1.Models;

namespace EFCore1;

internal class Program
{
    static void Main(string[] args)
    {
        using var db = new AppDbContext();

        AddUser(db, new User { Name = "Александр", Age = 25 });
        AddUsers(db, new List<User> {
                new User { Name = "Максим", Age = 30 },
                new User { Name = "Ирина", Age = 22 }
            });
        UpdateUser(db, 1, 26);
        UpdateAllUsers(db, 30);
        ShowUser(db, 1);
        ShowAllUsers(db);
        DeleteUser(db, 2);
        DeleteAllUsers(db);
    }

    static void AddUser(AppDbContext db, User user)
    {
        db.Users?.Add(user);
        db.SaveChanges();
    }

    static void AddUsers(AppDbContext db, List<User> users)
    {
        db.Users?.AddRange(users);
        db.SaveChanges();
    }

    static void UpdateUser(AppDbContext db, int id, int newAge)
    {
        var user = db.Users?.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            user.Age = newAge;
            db.SaveChanges();
        }
    }

    static void UpdateAllUsers(AppDbContext db, int newAge)
    {
        var users = db.Users?.Where(u => u.Age < newAge).ToList();
        if (users != null)
        {
            foreach (var user in users)
            {
                user.Age = newAge;
            }
            db.SaveChanges();
        }
    }

    static void DeleteUser(AppDbContext db, int id)
    {
        var user = db.Users?.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            db.Users?.Remove(user); // удаление одной записи
            db.SaveChanges();
        }
    }

    static void DeleteAllUsers(AppDbContext db)
    {
        var users = db.Users?.ToList();
        if (users != null && users.Any())
        {
            db.Users?.RemoveRange(users); // удаление всех записей
            db.SaveChanges();
        }
    }

    static void ShowUser(AppDbContext db, int id)
    {
        var user = db.Users?.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Age: {user.Age}");
        }
    }

    static void ShowAllUsers(AppDbContext db)
    {
        var users = db.Users?.ToList();
        if (users != null && users.Any())
        {
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Age: {user.Age}");
            }
        }
    }
}

