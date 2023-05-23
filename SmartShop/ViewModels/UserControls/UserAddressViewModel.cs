using SmartShop.Models;
using SmartShop.ViewModels.Base;

namespace SmartShop.ViewModels.UserControls
{
    public class UserAddressViewModel : BaseViewModel
    {
        public UserAddress CurAddress { get; set; }

        public UserAddressViewModel()
        {
        }
    }
}