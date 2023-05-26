namespace SmartShop.Models
{
    public class CartItemView : CartItem
    {
        public string ImgUrl { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int RemainQuantity { get; set; }
        public string Desc { get; set; }
        public string CategoryName { get; set; }
        public decimal ItemPrice => Quantity * Price; 
    }
}