namespace SmartShop.Models
{
    public class CartItem
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public string ProdID { get; set; }
        public int Quantity { get; set; }

        public Product Prod { get; set; } = new Product();
    }
}
