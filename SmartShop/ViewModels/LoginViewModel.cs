using System.Windows.Input;
using System.Windows;
using SmartShop.ViewModels.Base;
using System.Data.SqlClient;
using SmartShop.Repositories;
using SmartShop.Database;
using SmartShop.Views;
using SmartShop.Queries;
using SmartShop.ConvertToModel;

namespace SmartShop.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string username;
        public string Username { get => username; set { username = value; OnPropertyChanged(); } }

        private string password;
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }

        public string ServerName { get => CurrentDb.Ins.ServerName; set { CurrentDb.Ins.ServerName = value; OnPropertyChanged(); } }

        public ICommand LoginCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }

        public LoginViewModel()
        {
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
            // login
            var connectionString = CurrentDb.Ins.GetConnStr(username, password);
            var dbConn = new DbConnection(new SqlConnection(connectionString));
            var loginRepos = new LoginRepository(dbConn, new DbConverter(new ConvModelFactory()), new LoginQuery());
            var notification = loginRepos.CheckLogin(username, password);
            
            var usr = loginRepos.Login(username, password);
            MessageBox.Show("" + notification);
            if (usr == null) return;
            CurrentDb.Ins.Usr = usr;
            
            var mainWin = new MainWindow { DataContext = new MainViewModel(dbConn) };
            mainWin.ShowDialog();
            RefreshAllText();
        }

        private void RefreshAllText()
        {
            Username = "";
            Password = "";
        }
    }
}
