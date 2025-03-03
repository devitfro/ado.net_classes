using Microsoft.Data.SqlClient;
using System.Linq;

namespace lesson1_hw;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string connectionStr = "Server=localhost; Database=Storik; Integrated Security=True; TrustServerCertificate=True;";

        string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES ORDER BY 1";
        var tableNames = new List<string>();
        using (var connection = new SqlConnection(connectionStr))
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
                        {
                            Console.WriteLine("Нема данных в таблице.");
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

        for (int i = 0; i < tableNames.Count; i++)
        {
            Console.WriteLine($"{i + 1}.Table name: {tableNames[i]}");
        }

        int tableName;

        int action;

        Console.WriteLine("Choose number or name of table: ");


        while (true)
        {
            int userNameChoice = Convert.ToInt32(Console.ReadLine());
            if (userNameChoice > 0 && userNameChoice <= tableNames.Count)
            {
                tableName = userNameChoice;
                Console.WriteLine("aaa");
                break;
            }
            else
            {
                Console.WriteLine("Please, enter correct number..");
            }
        }

        Console.WriteLine("Выберите действие:\n" +
            "1. Показать структуру таблицы\n" +
            "2. Выбрать все данные с выводом на терминал\n" +
            "3. Вставить строку, данные вводятся с клавиатуры\n" +
            "4. Обновить строку по id\n" +
            "5. Удалить строку по id\n" +
            "6. Вернуться к списку таблиц");

        while (true)
        {
            int userActionChoice = Convert.ToInt32(Console.ReadLine());
            if (userActionChoice > 0 && userActionChoice < 7)
            {
                action = userActionChoice;
                break;
            }
            else
            {
                Console.WriteLine("Please, enter correct number..");
            }
        }


        showTableStructure(tableName);


        void showTableStructure(int ind)
        {
            string connectionStr = "Server=localhost; Database=Storik; Integrated Security=True; TrustServerCertificate=True;";
            
            string tableName = tableNames[ind - 1];
            string query = $"SELECT * FROM {tableName}";

            using (var connection = new SqlConnection(connectionStr))
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
                                Console.WriteLine("Нема данных в таблице.");
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }
        }
    }

    

    
}

