using SmartShop.Models;

namespace SmartShop
{
    public class OrderItem
    {
        public string ID { get; set; }
        public string OrderID { get; set; }
        public string ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
