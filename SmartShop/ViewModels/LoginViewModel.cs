using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SmartShop.Models;
using System.Windows.Input;
using System.Windows;
using SmartShop.ViewModels.Base;
using SmartShop.ViewModels.UserControls;
using System.Data.SqlClient;
using SmartShop.View;

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

       // private AccountsDao accountsDao = new AccountsDao();
        //private EmployeesDao employeesDao = new EmployeesDao();
        //private RolesDao rolesDao = new RolesDao();

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
            var buyerWindow = new BuyerWindow();
            string serverName = "(localdb)\\mssqllocaldb";
            string databaseName = "SmartShop";
            string userName = Username; 
            string password = Password;

            string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};User ID={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Success");
                    buyerWindow.Show();
                    RefreshAllText();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Lỗi SQL: " + ex.Message);
                    MessageBox.Show("Fail");
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void RefreshAllText()
        {
            Username = "";
            Password = "";
        }
    }
}
