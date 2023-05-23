using System.Collections.Generic;

namespace SmartShop.Models
{
    public class Product
    {
        public string ID { get; set; }
        public string CategoryID { get; set; }
        public string ImgUrl { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public Category Category { get; set; } = new Category();
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
