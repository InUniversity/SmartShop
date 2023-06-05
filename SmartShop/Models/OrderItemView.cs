using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Models
{
    public class OrderItemView : OrderItem
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
