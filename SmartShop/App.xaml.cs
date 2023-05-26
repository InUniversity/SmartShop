using System.Windows;
using SmartShop.View;
using SmartShop.ViewModels;

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
