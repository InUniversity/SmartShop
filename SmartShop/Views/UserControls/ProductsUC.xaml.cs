using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartShop.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ProductsUC.xaml
    /// </summary>
    public partial class ProductsUC : UserControl
    {
        public ProductsUC()
        {
            InitializeComponent();
            var products = GetProducts();
            if (products.Count > 0)
                ListViewProducts.ItemsSource = products;
        }
        private List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product("Product 1",205,"1.jpg"),
                new Product("tât chân tất tay may mặc",206,"E:/Lập trình window/WpfApp1/WpfApp1/2.jpg"),
                new Product("Product 3",207,"E:/Lập trình window/WpfApp1/WpfApp1/3.jpg"),
                new Product("Product 4",208,"E:/Lập trình window/WpfApp1/WpfApp1/4.jpg")

            };
        }
    }
}
