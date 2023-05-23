using System.Collections.Generic;

namespace SmartShop.Models
{
    public class Order
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public string ProductID { get; set; }
        public string OrderStatusID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public OrderStatu OrderStatu { get; set; } = new OrderStatu();
        public User User { get; set; } = new User();
    }
}
