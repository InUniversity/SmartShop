using System.Collections.Generic;

namespace SmartShop.Models
{
    public class User
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal WalletBalance { get; set; }
        public string RoleID { get; set; }

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
        public UserRole UserRole { get; set; } = new UserRole();
    }
}
