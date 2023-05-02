namespace SmartShop.Models
{
    public class CartItem
    {
        public string ID { get; set; }
        public string CartID { get; set; }
        public string ProductID { get; set; }
        public int Quantity { get; set; }
    
        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
