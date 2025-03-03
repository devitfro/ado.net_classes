using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace lesson1_hw;

class Program
{
    static readonly string connectionString = "Server=localhost; Database=Storik; Integrated Security=True; TrustServerCertificate=True;";

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var tableNames = GetTableNames();

        ShowTableNames(tableNames);

        int tableNumber  = ChooseTable(tableNames);
        Console.WriteLine($"tableNumber - {tableNumber}");

        ShowActionMenu();

        int actionNumber = ChooseAction();
        Console.WriteLine($"actionNumber - {actionNumber}");

        if (actionNumber == 1)
        {
            //showTableStructure(tableNumber, tableNames);
            ShowTableStructure(tableNames[tableNumber]);
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
                Console.WriteLine("Ошибка: " + ex.Message);
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
                        Console.WriteLine("Структура таблицы:");
                        while (reader.Read())
                        {
                            string columnName = reader.GetString(0);
                            string dataType = reader.GetString(1);
                            Console.WriteLine($"{columnName} - {dataType}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при получении структуры таблицы: " + ex.Message);
            }
        }
    }

    //static void showTableStructure(int ind, List<string> tableNames)
    //{
    //    string tableName = tableNames[ind - 1];

    //    string query = $@"
    //            SELECT COLUMN_NAME, DATA_TYPE
    //            FROM INFORMATION_SCHEMA.COLUMNS";

    //    using (var connection = new SqlConnection(connectionString))
    //    {
    //        try
    //        {
    //            connection.Open();

    //            using (var command = new SqlCommand(query, connection))
    //            {
    //                using (SqlDataReader reader = command.ExecuteReader())
    //                {
    //                    if (reader.HasRows)
    //                    {
    //                        while (reader.Read())
    //                        {
    //                            string columnName = reader.GetString(0);
    //                            string dataType = reader.GetString(1);

    //                        }
    //                    }
    //                    else
    //                    {
    //                        Console.WriteLine("Нема данных в таблице.");
    //                    }
    //                }
    //            }
    //        }

    //        catch (Exception ex)
    //        {
    //            Console.WriteLine("Ошибка: " + ex.Message);
    //        }
    //    }
    //}





    //static void showTableStructure(int ind, List<string> tableNames)
    //{
    //    string tableName = tableNames[ind - 1];

    //    string query = $"SELECT * FROM {tableName}";

    //    using (var connection = new SqlConnection(connectionString))
    //    {
    //        try
    //        {
    //            connection.Open();

    //            using (var command = new SqlCommand(query, connection))
    //            {
    //                using (SqlDataReader reader = command.ExecuteReader())
    //                {
    //                    if (reader.HasRows)
    //                    {
    //                        while (reader.Read())
    //                        {
    //                            for (int i = 0; i < reader.FieldCount; i++)
    //                            {
    //                                Console.Write($"{reader[i]} \t");
    //                            }
    //                            Console.WriteLine();


    //                        }
    //                    }
    //                    else
    //                    {
    //                        Console.WriteLine("Нема данных в таблице.");
    //                    }
    //                }
    //            }
    //        }

    //        catch (Exception ex)
    //        {
    //            Console.WriteLine("Ошибка: " + ex.Message);
    //        }
    //    }
    //}
}






