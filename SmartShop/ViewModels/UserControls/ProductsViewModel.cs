using SmartShop.ViewModels.Base;
using System.Collections.Generic;
using System.Windows.Input;
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
        private IReceiveCartItem cartIns;

        private User curUser = CurrentUser.Ins.Usr;

        public ProductsViewModel(ProductRepository prodRepos, IReceiveCartItem cartIns)
        {
            this.prodRepos = prodRepos;
            this.cartIns = cartIns; 
            LoadProducts();
            SetCommands();
        }

        private void LoadProducts()
        {
            var products = prodRepos.GetAll();
        }

        private void SetCommands()
        {
            AddToCartCommand = new RelayCommand<CartItem>(ExecuteAddToCard);
        }

        private void ExecuteAddToCard(CartItem item)
        {
            cartIns.Receive(item);
        }
    }
}
