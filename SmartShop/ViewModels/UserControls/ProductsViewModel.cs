using System;
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

        private Product selectedProduct;
        public Product SelectedProduct { get => selectedProduct; set { selectedProduct = value;
            Console.WriteLine("click item");
            OnPropertyChanged(); } }

        public ICommand PlusSelQtyProdCommand { get; private set; }
        public ICommand MinusSelQtyProdCommand { get; private set; }
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
            PlusSelQtyProdCommand = new RelayCommand<Product>(ExecutePlusSelQtyProd);
            MinusSelQtyProdCommand = new RelayCommand<Product>(ExecuteMinusSelQtyProd);
            AddToCartCommand = new RelayCommand<Product>(ExecuteAddToCard);
        }

        private void ExecutePlusSelQtyProd(Product prod)
        {
            if (prod.SelectedQuantity > prod.RemainQuantity) return;
            SelectedProduct.SelectedQuantity += 1;
            OnPropertyChanged(nameof(Prods));
        }

        private void ExecuteMinusSelQtyProd(Product prod)
        {
            if (prod.SelectedQuantity < 1) return;
            SelectedProduct.SelectedQuantity -= 1;
            OnPropertyChanged(nameof(Prods));
        }

        private void ExecuteAddToCard(Product prod)
        {
            cartIns.Receive(prod);
            LoadProducts();
        }
    }
}
