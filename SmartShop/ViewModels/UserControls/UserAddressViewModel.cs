using System.Collections.Generic;
using SmartShop.Models;
using SmartShop.ViewModels.Base;

namespace SmartShop.ViewModels.UserControls
{
    public class UserAddressViewModel : BaseViewModel
    {
        public User CurUser = CurrentUser.Ins.Usr;
        public UserAddress CurAddress => null;
        
        public List<UserAddress> Addresses { get; set; }

        public UserAddressViewModel()
        {
        }
    }
}