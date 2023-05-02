namespace SmartShop.Models
{
    public class UserAddress
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public string Details { get; set; }
    
        public User User { get; set; }
    }
}
