using System.Windows.Input;
using System.Windows;
using SmartShop.ViewModels.Base;
using System.Data.SqlClient;
using SmartShop.Repositories;
using SmartShop.ConvertToModel;
using SmartShop.Database;
using SmartShop.Queries;
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

        private LoginRepository login;

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
            MainWindow mainWindow = new MainWindow();
            string serverName = "(localdb)\\mssqllocaldb";
            string databaseName = "SmartShop";
            string connectionString = GetConnStrTemplate(serverName, databaseName, username, password);
            DbConnection dbConn = new DbConnection(new SqlConnection(connectionString));
            var mainWin = new MainWindow() { DataContext = new MainViewModel(dbConn) };
            InitLogin(serverName, databaseName);
            if (login.GetAuthorizedAccountID(username, password)!=null)
            {

                mainWin.ShowDialog();
                RefreshAllText();
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }
        
        private void InitLogin(string serverName, string databaseName)
        {
            var conStr = GetConnStrTemplate(serverName, databaseName);
            var con = new SqlConnection(conStr);
            var dbConn = new DbConnection(con);

            var dbConv = new DbConverter(new ConvModelFactory());
            var loginQuery = new LoginQuery();
            var loginAccount = new LoginRepository(dbConn, dbConv, loginQuery);
            this.login = loginAccount;
        }

        private string GetConnStrTemplate(string serverName, string databaseName, string username, string password)
        {
            return $"Data Source={serverName};Initial Catalog={databaseName};User ID={username};Password={password};";
        }
        
        private string GetConnStrTemplate(string serverName, string databaseName)
        {
            return $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True;";
        }

        private void RefreshAllText()
        {
            Username = "";
            Password = "";
        }
    }
}
