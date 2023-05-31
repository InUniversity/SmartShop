using System.Windows.Input;
using System.Windows;
using SmartShop.ViewModels.Base;
using System.Data.SqlClient;
using SmartShop.Repositories;
using SmartShop.Database;
using SmartShop.Models;
using SmartShop.Views;

namespace SmartShop.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string username;
        public string Username { get => username; set { username = value; OnPropertyChanged(); } }

        private string password;
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }

        public ICommand LoginCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }

        private readonly LoginRepository loginRepos;

        public LoginViewModel(LoginRepository loginRepos)
        {
            this.loginRepos = loginRepos;
            SetCommands();
        }

        private void SetCommands()
        {
            LoginCommand = new RelayCommand<Window>(ExecuteLoginCommand);
            ExitCommand = new RelayCommand<Window>(ExecuteExitCommand);
        }

        private void ExecuteExitCommand(Window window)
        {
            window.Close();
        }

        private void ExecuteLoginCommand(Window window)
        {
            var usr = loginRepos.Login(username, password, out var notification);
            MessageBox.Show(notification, "", MessageBoxButton.OK);
            if (usr == null) return;
            CurrentDb.Ins.Usr = usr;
            ShowMainWindow(CurrentDb.serverName, CurrentDb.dbName, username, password);
            RefreshAllText();
        }

        private void ShowMainWindow(string serverName, string databaseName, string username, string password)
        {
            var connectionString = GetConnStrTemplate(serverName, databaseName, username, password);
            var dbConn = new DbConnection(new SqlConnection(connectionString));
            var mainWin = new MainWindow { DataContext = new MainViewModel(dbConn) };
            mainWin.ShowDialog();
        }

        private string GetConnStrTemplate(string serverName, string databaseName, string username, string password)
        {
            return $"Data Source={serverName};Initial Catalog={databaseName};User ID={username};Password={password};";
        }

        private void RefreshAllText()
        {
            Username = "";
            Password = "";
        }
    }
}
