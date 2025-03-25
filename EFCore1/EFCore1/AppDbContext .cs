using EFCore1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore1
{
    public class AppDbContext : DbContext
    {
        public DbSet<User>? Users { get; set; } // это будет название таблицы в БД

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Store;" +
                "Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
