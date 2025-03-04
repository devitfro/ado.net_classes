using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace lesson1_hw;

class Program
{
    static string connectionString;

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appconfig.json")
           .Build();

        connectionString = configuration.GetConnectionString("DefaultConnection");

        var tableNames = GetTableNames();

        ShowTableNames(tableNames);

        int tableNumber  = ChooseTable(tableNames);

        string tableName = tableNames[tableNumber - 1];

        Console.WriteLine($"tableNumber - {tableNumber}");

        while (true)
        {
            ShowActionMenu();

            int actionNumber = ChooseAction();
            Console.WriteLine("Action: " +  actionNumber);

            switch (actionNumber)
            {
                case 1:
                    ShowTableStructure(tableName);
                    break;
                case 2:
                    ShowDataInformation(tableName);
                    break;
                case 3:
                    InsertRow(tableName);
                    break;
                case 4:
                    UpdateRow(tableName);
                    break;
                case 5:
                    DeleteRow(tableName);
                    break;
                case 6:
                    ClearScreen();
                    ShowTableNames(tableNames);
                    break;
                default:
                    Console.WriteLine("Not correct input...");
                    break;
            }
        }
    }

    static List<string> GetTableNames()
    {
        var tableNames = new List<string>();
        string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES ORDER BY 1";
        using (var connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var row = reader.GetString(0);
                                tableNames.Add(row);
                            }
                        }
                        else    
                            Console.WriteLine("Нема данных в таблице.");                     
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        return tableNames;
    }

    static void ShowTableNames(List<string> tableNames)
    {
        for (int i = 0; i < tableNames.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tableNames[i]}");
        }
    }

    static int ChooseTable(List<string> tableNames)
    {
        Console.WriteLine("Choose number or name of table: ");
        while (true)
        {
            int tableNumber = Convert.ToInt32(Console.ReadLine());
            if (tableNumber > 0 && tableNumber <= tableNames.Count)
            {
                return tableNumber;
            }
            else
            {
                Console.WriteLine("Please, enter correct number..");
            }
        }
    }

    static void ShowActionMenu()
    {
        Console.WriteLine("Выберите действие:\n" +
           "1. Показать структуру таблицы\n" +
           "2. Выбрать все данные с выводом на терминал\n" +
           "3. Вставить строку, данные вводятся с клавиатуры\n" +
           "4. Обновить строку по id\n" +
           "5. Удалить строку по id\n" +
           "6. Вернуться к списку таблиц");
    }

    static int ChooseAction()
    {
        while (true)
        {
            int actionNumber = Convert.ToInt32(Console.ReadLine());
            if (actionNumber > 0 && actionNumber <= 6)
            {
                return actionNumber;
            }
            else
            {
                Console.WriteLine("Please, enter correct number..");
            } 
        }
    }
       

    static void ShowTableStructure(string tableName)
    {
        string query = $@"
                SELECT COLUMN_NAME, DATA_TYPE 
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME = @TableName";

        using (var connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TableName", tableName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.Write($"{reader[i]} \t");
                                }
                                Console.WriteLine();                  
                            }
                        }
                        else
                        {
                            Console.WriteLine("No data in the table.");
                        }
                        Console.WriteLine();
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static void ShowDataInformation(string tableName)
    {
        string query = $"SELECT * FROM {tableName}";

        using (var connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.Write($"{reader[i]} \t");
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No data in the table.");
                        }
                        Console.WriteLine();
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static void InsertRow(string tableName)
    {
        Console.WriteLine("Enter data to insert into the table: ");

        string values = Console.ReadLine();

        string query = $"INSERT INTO {tableName} VALUES ({values})";

        using (var connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static void UpdateRow(string tableName)
    {
        Console.Write("Enter row id to update: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter value: ");
        string newValue = Console.ReadLine();

        string query = $"UPDATE {tableName} SET {newValue} WHERE id = {id}";

        using (var connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static void DeleteRow(string tableName)
    {
        Console.Write("Enter row id to delete: ");

        int id = int.Parse(Console.ReadLine());

        string query = $"DELETE FROM {tableName} WHERE id = {id}";

        using (var connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static void ClearScreen()
    {
        Console.Clear();
    }
}






