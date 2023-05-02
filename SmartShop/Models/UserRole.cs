using SmartShop.Models;
using System.Collections.Generic;

namespace SmartShop
{
    public class UserRole
    {
        public string ID { get; set; }
        public string RoleName { get; set; }
    
        public ICollection<User> Users { get; set; }
    }
}
