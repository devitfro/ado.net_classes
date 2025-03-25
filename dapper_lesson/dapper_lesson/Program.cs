using Microsoft.Data.SqlClient;
using Dapper;
using System.Text;

namespace _7._Dapper
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            string connectionString = "Server=localhost;Database=Store;Trusted_Connection=True;TrustServerCertificate=True;";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // пример получения скалярного значения (например, общая выручка если всё продать)
                var productCount = GetScalarValue(connection);
                Console.WriteLine($"Общая выручка: {productCount} грн.");

                // пример получения одной строки (по id)
                var singleProduct = GetProductById(connection, 1);
                Console.WriteLine($"Продукт по айди: {singleProduct?.Name} {singleProduct?.Price}");

                // пример выполнения запроса с группировкой
                var categories = GetCategoriesAndProductCount(connection);
                Console.WriteLine("\nКатегория - Количество продуктов в ней");
                foreach (var category in categories)
                {
                    Console.WriteLine($"{category.Name} - {category.ProductCount}");
                }

                // пример вставки данных
                InsertProduct(connection, "Шаурма Обычная", 249.50m, 1, 10);

                // пример обновления данных
                UpdateProduct(connection, 1, "Шаурма Ассорти", 315.50m);

                // пример удаления данных + несколько запросов в одном методе
                DeleteProduct(connection, 3);
            }
        }

        static IEnumerable<Product> GetProducts(SqlConnection connection)
        {
            return connection.Query<Product>("SELECT * FROM Product");
        }

        // получение скалярного значения
        static int GetScalarValue(SqlConnection connection)
        {
            return connection.ExecuteScalar<int>("SELECT SUM(quantity * price) FROM Product");
        }

        // получение одной строки по id
        static Product? GetProductById(SqlConnection connection, int id)
        {
            return connection.QuerySingleOrDefault<Product>("SELECT * FROM Product WHERE id = @Id", new { Id = id });
        }

        // получение списка категорий с количеством продуктов в каждой
        static IEnumerable<CategoryWithProductCount> GetCategoriesAndProductCount(SqlConnection connection)
        {
            return connection.Query<CategoryWithProductCount>(@"
                SELECT c.Name, COUNT(p.id) AS ProductCount
                FROM Category c
                LEFT JOIN Product p ON c.id = p.id_category
                GROUP BY c.Name");
        }

        // вставка нового продукта
        static void InsertProduct(SqlConnection connection, string name, decimal price, int categoryId, int quantity)
        {
            var query = "INSERT INTO Product (name, price, id_category, quantity) VALUES (@Name, @Price, @CategoryId, @Quantity)";
            connection.Execute(query, new { Name = name, Price = price, CategoryId = categoryId, Quantity = quantity });
        }

        // обновление данных продукта
        static void UpdateProduct(SqlConnection connection, int id, string name, decimal price)
        {
            var query = "UPDATE Product SET name = @Name, price = @Price WHERE id = @Id";
            connection.Execute(query, new { Id = id, Name = name, Price = price });
        }

        // удаление продукта
        static void DeleteProduct(SqlConnection connection, int id)
        {
            // на всякий случай дропаем продукт из поставок и продаж, иначе не удалится
            var deleteDeliveryQuery = "DELETE FROM Delivery WHERE id_product = @Id";
            connection.Execute(deleteDeliveryQuery, new { Id = id });

            var deleteSaleQuery = "DELETE FROM Sale WHERE id_product = @Id";
            connection.Execute(deleteSaleQuery, new { Id = id });

            var query = "DELETE FROM Product WHERE id = @Id";
            connection.Execute(query, new { Id = id });
        }
    }

    // модель для продукта
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int IdCategory { get; set; }
        public int Quantity { get; set; }
    }

    // модель для категории с количеством продуктов
    public class CategoryWithProductCount
    {
        public string? Name { get; set; }
        public int ProductCount { get; set; }
    }
}