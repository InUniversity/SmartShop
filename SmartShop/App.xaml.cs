using System.Data.SqlClient;
using System.Windows;
using SmartShop.Database;
using SmartShop.Models;
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
            //CurrentUser.Ins.Usr.ID = "USR0001";
            //InitMainWindow();
            //base.OnStartup(e);
            InitLogin();
            base.OnStartup(e);
        }

        private void InitMainWindow()
        {
            var conStr = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=SmartShop;Integrated Security=True";
            var con = new SqlConnection(conStr);
            var dbConn = new DbConnection(con);
            var viewModel = new MainViewModel(dbConn);
            var window = new MainWindow { DataContext = viewModel };
            window.Show();
        }

        private void InitLogin()
        {
            var viewModel = new LoginViewModel();
            var window = new Login { DataContext = viewModel };
            window.Show();
        }
    }
}
