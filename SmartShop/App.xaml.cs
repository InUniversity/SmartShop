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
            Init();
            base.OnStartup(e);
        }

        private void Init()
        {
            // Init DAO
            var dbConn = new DbConnection();
            var prodRepos = new ProductRepository(dbConn);

            // Init ViewModel
            var cartVM = new CartViewModel();
            var cartView = new CartUC { DataContext = cartVM };
            
            var prodVM = new ProductsViewModel(prodRepos, cartVM);
            var prodView = new ProductsUC { DataContext = prodVM };
            
            // Init View
            var viewModel = new BuyerViewModel(prodView, cartView);
            var window = new BuyerWindow { DataContext = viewModel };
            window.Show();
        }
    }
}
