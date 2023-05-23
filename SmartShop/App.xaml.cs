using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SmartShop.Database;
using SmartShop.Repositories;
using SmartShop.View;
using SmartShop.ViewModels;
using SmartShop.ViewModels.UserControls;
using SmartShop.Views.UserControls;

namespace SmartShop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var window = CreateBuyerView();
            window.Show();
            base.OnStartup(e);
        }

        private BuyerWindow CreateBuyerView()
        {
            var viewModel = CreateBuyerVM();
            return new BuyerWindow { DataContext = viewModel };
        }

        private BuyerViewModel CreateBuyerVM()
        {
            var prodView = CreateProdView();
            var cartView = CreateCartView();
            return new BuyerViewModel(prodView, cartView);
        }
        
        private ProductsUC CreateProdView()
        {
            return new ProductsUC { DataContext = CreateProdVM() };
        }

        private ProductsViewModel CreateProdVM()
        {
            var dbConn = new DbConnection();
            var prodRepos = new ProductRepository(dbConn);
            return new ProductsViewModel(prodRepos);
        }

        private CartUC CreateCartView()
        {
            return new CartUC { DataContext = CreateCartVM() };
        }

        private CartViewModel CreateCartVM()
        {
            return new CartViewModel();
        }
    }
}
