using System;

namespace SmartShop.Models
{
    public class Cart
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
