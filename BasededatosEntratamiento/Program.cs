using BasededatosEntratamiento.Data;
using BasededatosEntratamiento.Models;


namespace BasededatosEntratamiento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                // Ensure database is created
                context.Database.EnsureCreated();

                // Add seed data to Products table if it doesn't exist
                //if (!context.Products.Any())
                //{
                //    context.Products.AddRange(
                //        new Product { Name = "Laptop", Price = 1000.00m },
                //        new Product { Name = "Smartphone", Price = 800.00m },
                //        new Product { Name = "Tablet", Price = 500.00m }
                //    );
                //    context.SaveChanges();
                //}

                // Add orders to Orders table
                //if (!context.Orders.Any())
                //{
                //    context.Orders.AddRange(
                //        new Order { ProductId = 1, Quantity = 2 }, // Order for 2 Laptops
                //        new Order { ProductId = 2, Quantity = 1 }, // Order for 1 Smartphone
                //        new Order { ProductId = 3, Quantity = 3 }, // Order for 3 Tablets
                //        new Order { ProductId = 1, Quantity = 5 }  // Order for 5 Laptops
                //    );
                //    context.SaveChanges();
                //}

                // Display all orders
                Console.WriteLine("Orders in the database:");
                var orders = context.Orders
                    .Join(context.Products,
                        order => order.ProductId,
                        product => product.Id,
                        (order, product) => new
                        {
                            order.OrderId,
                            product.Name,
                            order.Quantity,
                            TotalPrice = product.Price * order.Quantity
                        });
                var Products_ = context.Products;
                foreach (var order in orders)
                {
                    Console.WriteLine($"OrderId: {order.OrderId}, Product: {order.Name}, Quantity: {order.Quantity}, Total Price: {order.TotalPrice:C}");
                }
                foreach (var product  in Products_)
                {
                    Console.WriteLine($"OrderId2: {product.Id}, Product: {product.Name}, Quantity: {product.Price}");
                }
            }
        }
    }
}
