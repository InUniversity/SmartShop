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
            var conStr = GetConnStrTemplate(CurrentDb.serverName, CurrentDb.dbName);
            var con = new SqlConnection(conStr);
            var dbConn = new DbConnection(con);
            var dbConv = new DbConverter(new ConvModelFactory());
            var loginQuery = new LoginQuery();
            var loginRepos = new LoginRepository(dbConn, dbConv, loginQuery);
            var viewModel = new LoginViewModel(loginRepos);
            var window = new Login { DataContext = viewModel };
            window.Show();
        }
        
        private string GetConnStrTemplate(string serverName, string databaseName)
        {
            return $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True;";
        }
    }
}
