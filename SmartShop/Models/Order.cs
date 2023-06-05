using System;
using System.Collections.Generic;

namespace SmartShop.Models
{
    public class Order
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public DateTime Date { get; set; }

        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }

        public List<OrderItemView> Items { get; set; }
    }
}
