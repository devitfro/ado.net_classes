// для нового консольного проекта, необходимо выполнить такие команды в терминале:
// dotnet add package Microsoft.EntityFrameworkCore.SqlServer
// dotnet add package Microsoft.EntityFrameworkCore.Tools
// dotnet ef migrations add FirstMigration
// dotnet ef database update

using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Person>? People { get; set; }
    public DbSet<Hobby>? Hobbies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=PeopleHobbies;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Person>()
            .HasKey(p => p.PersonId);

        modelBuilder.Entity<Hobby>()
            .HasKey(h => h.HobbyId);

        modelBuilder.Entity<Person>()
            .Property(p => p.Name) // Fluent API example
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<Hobby>()
            .Property(h => h.Name)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<Person>()
            .HasMany(p => p.Hobbies)
            .WithMany(h => h.People)
            .UsingEntity(j => j.ToTable("PersonHobbies"));
    }

    public void ResetDatabase()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
        Console.WriteLine("База данных очищена и пересоздана.");
    }
}

public class Person
{
    public int PersonId { get; set; }
    public string? Name { get; set; }
    public ICollection<Hobby> Hobbies { get; set; } = new List<Hobby>();
}

public class Hobby
{
    public int HobbyId { get; set; }
    public string? Name { get; set; }
    public ICollection<Person> People { get; set; } = new List<Person>();
}

public class PersonBuilder
{
    private Person _person = new Person();

    public PersonBuilder SetName(string name)
    {
        _person.Name = name;
        return this;
    }

    public PersonBuilder AddHobby(Hobby hobby)
    {
        _person.Hobbies.Add(hobby);
        return this;
    }

    public Person Build() => _person;
}

public class HobbyBuilder
{
    private Hobby _hobby = new Hobby();

    public HobbyBuilder SetName(string name)
    {
        _hobby.Name = name;
        return this;
    }

    public Hobby Build() => _hobby;
}

public class PersonRepository
{
    public void GetAllPeople()
    {
        using var context = new ApplicationDbContext();
        var people = context.People?
            .Include(p => p.Hobbies) // Fluent API example
            .OrderBy(p => p.Name)
            .ToList();

        people?.ForEach(person =>
        {
            Console.WriteLine($"{person.Name}");
            person.Hobbies.ToList().ForEach(hobby => Console.WriteLine($" - Увлечение: {hobby.Name}"));
        });
    }

    public void AddPerson(string name, List<string> hobbies)
    {
        using var context = new ApplicationDbContext();
        var person = new PersonBuilder()
            .SetName(name)
            .Build();

        hobbies.ForEach(hobbyName =>
        {
            var hobby = context.Hobbies?
                .FirstOrDefault(h => h.Name == hobbyName) ?? new HobbyBuilder().SetName(hobbyName).Build();
            person.Hobbies.Add(hobby);
        });

        context.People?.Add(person);
        context.SaveChanges();
        Console.WriteLine($"Человек {name} добавлен!");
    }

    public void UpdatePersonHobbies(string personName, List<string> newHobbies)
    {
        using var context = new ApplicationDbContext();
        var person = context.People?
            .Include(p => p.Hobbies) // Fluent API example
            .FirstOrDefault(p => p.Name == personName);

        if (person == null)
        {
            Console.WriteLine($"Человек с именем {personName} не найден.");
            return;
        }

        person.Hobbies.Clear();
        newHobbies.ForEach(hobbyName =>
        {
            var hobby = context.Hobbies?
                .FirstOrDefault(h => h.Name == hobbyName) ?? new HobbyBuilder().SetName(hobbyName).Build();
            person.Hobbies.Add(hobby);
        });

        context.SaveChanges();
        Console.WriteLine($"Увлечения {personName} обновлены!");
    }

    public void DeletePerson(string personName)
    {
        using var context = new ApplicationDbContext();
        var person = context.People?
            .Include(p => p.Hobbies)
            .FirstOrDefault(p => p.Name == personName);

        if (person == null)
        {
            Console.WriteLine($"Человек с именем {personName} не найден.");
            return;
        }

        context.People?.Remove(person);
        context.SaveChanges();
        Console.WriteLine($"Человек {personName} удален!");
    }
}

internal class Program
{
    static void Main()
    {
        using var context = new ApplicationDbContext();
        context.ResetDatabase();

        var repo = new PersonRepository();

        repo.AddPerson("Александр", new List<string> { "Футбол", "Чтение" });
        repo.AddPerson("Артём", new List<string> { "Рисование", "Путешествия" });
        repo.GetAllPeople();

        repo.UpdatePersonHobbies("Александр", new List<string> { "Готовка", "Путешествия" });
        repo.GetAllPeople();
    }
}