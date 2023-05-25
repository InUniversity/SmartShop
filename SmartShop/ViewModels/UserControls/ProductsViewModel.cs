using SmartShop.ViewModels.Base;
using System.Collections.Generic;
using System.Windows.Input;
using SmartShop.Adapters;
using SmartShop.Models;
using SmartShop.Repositories;

namespace SmartShop.ViewModels.UserControls
{
    public class ProductsViewModel : BaseViewModel
    {
        private List<Product> prods;
        public List<Product> Prods { get => prods; set { prods = value; OnPropertyChanged(); } }
        
        public ICommand AddToCartCommand { get; private set; }

        private readonly ProductRepository prodRepos;
        private IReceiveProduct cartIns;

        private User curUser = CurrentUser.Ins.Usr;

        public ProductsViewModel(ProductRepository prodRepos, IReceiveProduct cartIns)
        {
            this.prodRepos = prodRepos;
            this.cartIns = cartIns; 
            LoadProducts();
            SetCommands();
        }

        private void LoadProducts()
        {
            Prods = prodRepos.GetAll();
        }

        private void SetCommands()
        {
            AddToCartCommand = new RelayCommand<Product>(ExecuteAddToCard);
        }

        private void ExecuteAddToCard(Product prod)
        {
            cartIns.Receive(prod);
        }
    }
}
