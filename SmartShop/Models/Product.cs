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
    
        public ICollection<CartItem> CartItems { get; set; }
        public Category Category { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
