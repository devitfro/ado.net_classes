using System.Data;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string connectionString = "Server=localhost; Database=Store; Integrated Security=True; TrustServerCertificate=True;";

        string query = "SELECT id, name, price FROM Product";

        // создание объекта DataTable для хранения данных !!!!! отсоединённый режим !!!!!
        var productTable = new DataTable();

        // создание подключения
        using (var connection = new SqlConnection(connectionString))
        {
            try
            {
                // открытие соединения с базой данных
                connection.Open();

                // создание команды для выполнения запроса
                using (var command = new SqlCommand(query, connection))
                {
                    // создание адаптера для заполнения DataTable
                    var dataAdapter = new SqlDataAdapter(command);

                    // заполняем DataTable данными из базы данных
                    dataAdapter.Fill(productTable);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

        // теперь база данных отсоединена, данные находятся в DataTable, и мы можем работать с ними локально

        // фильтрация данных по цене (меньше 100 грн)
        // var filteredRows = productTable.Select("price < 100"); // не запоминает порядок строк

        var filteredRows = productTable.AsEnumerable()
           .Where(row => row.Field<double>("price") < 100)
           .OrderBy(row => row.Field<int>("id")) // сортировка по id
           .ToArray();

        // вывод отфильтрованных данных
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