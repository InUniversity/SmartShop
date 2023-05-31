using System.Collections.Generic;

namespace SmartShop.Models
{
    public class User
    {
        public string ID { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal WalletBalance { get; set; }
        public string RoleID { get; set; }

        public ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
    }
}
