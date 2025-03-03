using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
 // NuGet: Microsoft.Extensions.Configuration, Microsoft.Extensions.Configuration.Json

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // загружаем конфигурацию
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appconfig.json")
            .Build();

        // получаем строку подключения из конфигурации
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        string query = "SELECT id, name, price FROM Product";

        var productTable = new DataTable();

        using (var connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    var dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(productTable);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

        var filteredRows = productTable.AsEnumerable()
            .Where(row => row.Field<double>("price") < 100)
            .OrderBy(row => row.Field<int>("id"))
            .ToArray();

        if (filteredRows.Length > 0)
        {
            Console.WriteLine("Продукты с ценой меньше 100 грн:");
            foreach (var row in filteredRows)
            {
                Console.WriteLine($"{row["id"]}, {row["name"]}, {row["price"]}грн.");
            }
        }
        else
        {
            Console.WriteLine("Нет продуктов с ценой меньше 100 грн.");
        }

        Console.ReadLine();
    }
}