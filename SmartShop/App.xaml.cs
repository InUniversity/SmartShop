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
            var viewModel = new BuyerViewModel();
            var window = new BuyerWindow { DataContext = viewModel };
            window.Show();
        }
    }
}
