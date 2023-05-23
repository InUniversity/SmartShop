using System.Collections.Generic;

namespace SmartShop.Models
{
    public class OrderStatu
    {
        public string ID { get; set; }
        public string StatusName { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
