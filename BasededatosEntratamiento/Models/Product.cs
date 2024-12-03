using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasededatosEntratamiento.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        // Relación con la tabla Orders
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }

    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        // Relación con la tabla Products
        public Product Product { get; set; }
    }

}
