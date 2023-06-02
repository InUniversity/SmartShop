using System.Data.SqlClient;
using System.Windows;
using SmartShop.ConvertToModel;
using SmartShop.Database;
using SmartShop.Models;
using SmartShop.Queries;
using SmartShop.Repositories;
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
            var window = new Login { DataContext = viewModel };
            window.Show();
        }
    }
}
