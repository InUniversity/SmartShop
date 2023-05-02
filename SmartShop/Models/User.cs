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
    
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<UserAddress> UserAddresses { get; set; }
        public UserRole UserRole { get; set; }
    }
}
