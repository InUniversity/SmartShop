using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
            var viewModel = new BuyerViewModel();
            var window = new BuyerWindow {DataContext = viewModel};
            window.Show();
            base.OnStartup(e);
        }
    }
}
