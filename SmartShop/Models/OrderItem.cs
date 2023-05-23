using SmartShop.Models;

namespace SmartShop
{
    public class OrderItem
    {
        public string ID { get; set; }
        public string OrderID { get; set; }
        public string ProdID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        
        public Product Prod { get; set; } = new Product();
    }
}
