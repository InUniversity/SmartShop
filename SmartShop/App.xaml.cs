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
            InitMainWindow();
            base.OnStartup(e);
        }

        private void InitMainWindow()
        {
            var viewModel = new MainViewModel();
            var window = new MainWindow { DataContext = viewModel };
            window.Show();
        }
    }
}
