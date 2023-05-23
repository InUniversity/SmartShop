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
            // TODO
            // Products = prodRepos.GetAll();
            Products = new List<Product>()
            {
                new Product { ID = "123123" },
                new Product { ID = "123124" },
                new Product { ID = "123125" },
                new Product { ID = "123126" }
            };
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
