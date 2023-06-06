using System.Windows;
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
            InitLogin();
            base.OnStartup(e);
        }

        private void InitLogin()
        {
            var viewModel = new LoginViewModel();
            var window = new LoginWindow { DataContext = viewModel };
            window.Show();
        }
    }
}
