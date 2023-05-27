using System.Windows;
using SmartShop.View;
using SmartShop.ViewModels;
using SmartShop.Views;

namespace SmartShop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // InitBuyer();
            InitSeller();
            base.OnStartup(e);
        }

        private void InitBuyer()
        {
            var viewModel = new BuyerViewModel();
            var window = new BuyerWindow { DataContext = viewModel };
            window.Show();
        }

        private void InitSeller()
        {
            var viewModel = new SellerViewModel();
            var window = new SellerWindow { DataContext = viewModel };
            window.Show();
        }
    }
}
