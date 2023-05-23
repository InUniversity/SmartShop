namespace SmartShop.Models
{
    public class CartItem
    {
        public string ID { get; set; }
        public string CartID { get; set; }
        public string ProdID { get; set; }
        public int Quantity { get; set; }

        public Cart Cart { get; set; } = new Cart();
        public Product Product { get; set; } = new Product();
    }
}
