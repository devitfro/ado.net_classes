using EFCore1.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore1;

public class AppDbContext : DbContext
{
    public DbSet<User>? Users { get; set; } // это будет название таблицы в БД

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=MyDatabase;" +
            "Trusted_Connection=True;TrustServerCertificate=True;");
    }
}