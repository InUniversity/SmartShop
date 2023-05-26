namespace SmartShop.Models
{
    public class Product
    {
        public string ID { get; set; }
        public string CategoryID { get; set; }
        public string ImgUrl { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int RemainQuantity { get; set; }
        public string Desc { get; set; }
        
        public int SelectedQuantity { get; set; } = 1;
    }
}
