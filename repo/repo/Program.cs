using Microsoft.EntityFrameworkCore;
using repo.Models;
using repo.Repositories;
using System;


internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        using (var context = new MyDbContext())
        {
            var userRepository = new UserRepository(context);

            var newUser = new User { Name = "Emilieeee", Age = 25 };

            userRepository.Add(newUser);

            var userById = userRepository.GetById(3);

            if (userById != null)
            {
                Console.WriteLine($"User found: {userById.Name}, Age: {userById.Age}");
            }
            else
            {
                Console.WriteLine("User not found.");
            }

            var userList = userRepository.GetAll();

            foreach (var user in userList)
            {
                Console.WriteLine(user.Name);
            }

            newUser.Name = "Lelik";
            newUser.Age = 27;

            userRepository.Update(newUser);

            var updatedUser = userRepository.GetById(newUser.Id);

            Console.WriteLine($"Updated User: {updatedUser.Name}, Age: {updatedUser.Age}");

            userRepository.Delete(12);
        }
    }
}