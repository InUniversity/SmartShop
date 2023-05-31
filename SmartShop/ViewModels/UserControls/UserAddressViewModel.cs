using System.Collections.Generic;
using SmartShop.Database;
using SmartShop.Models;
using SmartShop.Repositories;
using SmartShop.ViewModels.Base;

namespace SmartShop.ViewModels.UserControls
{
    public class UserAddressViewModel : BaseViewModel
    {
        public User CurUser = CurrentDb.Ins.Usr;
        public UserAddress CurAddress => null;
        
        public List<UserAddress> Addresses { get; set; }

        private readonly UserAddressRepository addressRepos;

        public UserAddressViewModel(UserAddressRepository addressRepos)
        {
            this.addressRepos = addressRepos;
        }

        private void LoadAddresses()
        {
            Addresses = addressRepos.SearchByUserID(CurUser.ID);
        }
    }
}