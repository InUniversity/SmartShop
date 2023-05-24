using System.Windows.Controls;
using System.Windows.Input;
using SmartShop.ConvertToModel;
using SmartShop.Database;
using SmartShop.Repositories;
using SmartShop.ViewModels.Base;
using SmartShop.ViewModels.UserControls;
using SmartShop.Views.UserControls;

namespace SmartShop.ViewModels
{
    public class BuyerViewModel : BaseViewModel, INavigateView
    {
        private ContentControl currentChildView;
        public ContentControl CurrentChildView { get => currentChildView; set { currentChildView = value; OnPropertyChanged(); } }

        private ProductsUC prodsView;
        private CartUC cartView;
        private PaymentUC paymentView;
        
        public ICommand MoveToProductsViewCommand { get; private set; }
        public ICommand MoveToCartViewCommand { get; private set; }

        public BuyerViewModel()
        {
            InitComponentsView();
            MoveToProductsView();
            SetCommands();
        }

        private void InitComponentsView()
        {
            var dbConn = new DbConnection();
            var convModelFactory = new ConvModelFactory();
            var dbConv = new DbConverter(convModelFactory);
            
            var prodRepos = new ProductRepository(dbConn, dbConv);
            var orderRepos = new OrderRepository(dbConn, dbConv);
            var addressRepos = new UserAddressRepository(dbConn, dbConv);

            var userAddressVM = new UserAddressViewModel(addressRepos);
            var orderItemsVM = new OrderItemsViewModel(orderRepos);
            var paymentVM = new PaymentViewModel(userAddressVM, orderItemsVM);
            var cartVM = new CartViewModel(paymentVM, this);
            var prodVM = new ProductsViewModel(prodRepos, cartVM);
            
            paymentView = new PaymentUC { DataContext = paymentVM };
            cartView = new CartUC { DataContext = cartVM };
            prodsView = new ProductsUC { DataContext = prodVM };
        }

        private void SetCommands()
        {
            MoveToProductsViewCommand = new RelayCommand<object>(_ => MoveToProductsView());
            MoveToCartViewCommand = new RelayCommand<object>(_ => MoveToCartView());
        }

        public void MoveToProductsView()
        {
            CurrentChildView = prodsView;
        }

        public void MoveToCartView()
        {
            CurrentChildView = cartView;
        }

        public void MoveToPaymentView()
        {
            CurrentChildView = paymentView;
        }
    }
}
