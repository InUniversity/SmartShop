using SmartShop.ViewModels.Base;
using System.Collections.Generic;
using System.Windows.Input;
using SmartShop.Models;
using SmartShop.Repositories;

namespace SmartShop.ViewModels.UserControls
{
    public class ProductsViewModel : BaseViewModel
    {
        private List<CartItem> cartItems;
        public List<CartItem> CartItems { get => cartItems; set { cartItems = value; OnPropertyChanged(); } }
        
        public ICommand AddToCartCommand { get; private set; }

        private readonly ProductRepository prodRepos;
        private IReceiveCartItem cartIns;

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
            // Init cart item from product items 
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
