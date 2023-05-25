using System;
using System.Collections.Generic;

namespace SmartShop.Models
{
    public class Order
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public string StatusID { get; set; }
        public DateTime Date { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public OrderStatus Status { get; set; } = new OrderStatus();
        public User User { get; set; } = new User();
    }
}
