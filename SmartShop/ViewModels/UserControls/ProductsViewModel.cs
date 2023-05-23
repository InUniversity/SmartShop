using SmartShop.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using SmartShop.Models;
using SmartShop.Repositories;

namespace SmartShop.ViewModels.UserControls
{
    public class ProductsViewModel : BaseViewModel
    {
        private List<Product> products;
        public List<Product> Products { get => products; set { products = value; OnPropertyChanged(); } }
        
        public ICommand AddToCartCommand { get; private set; }

        private readonly ProductRepository prodRepos;

        public ProductsViewModel(ProductRepository prodRepos)
        {
            this.prodRepos = prodRepos;
            LoadProducts();
            SetCommands();
        }

        private void LoadProducts()
        {
            Products = prodRepos.GetAll();
        }

        private void SetCommands()
        {
            AddToCartCommand = new RelayCommand<Product>(ExecuteAddToCard);
        }

        private void ExecuteAddToCard(Product prod)
        {
            throw new NotImplementedException();
        }
    }
}
