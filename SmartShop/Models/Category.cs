using System.Collections.Generic;

namespace SmartShop.Models
{
    public class Category
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
