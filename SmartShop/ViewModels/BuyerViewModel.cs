using System.Windows.Controls;
using System.Windows.Input;
using SmartShop.Adapters;
using SmartShop.ConvertToModel;
using SmartShop.Database;
using SmartShop.Models;
using SmartShop.Queries;
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

        public int CartQuantity => cartItemRepos.GetTotalQuantity(CurrentUser.Ins.Usr.ID);
        
        public ICommand MoveToProductsViewCommand { get; private set; }
        public ICommand MoveToCartViewCommand { get; private set; }

        private CartItemRepository cartItemRepos;

        private ProductsUC prodsView;
        private CartUC cartView;
        private PaymentUC paymentView;

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

            var prodQuery = new ProductQuery();
            var orderQuery = new OrderQuery();
            var addressQuery = new UserAddressQuery();
            var cartItemQuery = new CartItemQuery();
            
            var prodRepos = new ProductRepository(dbConn, dbConv, prodQuery);
            var orderRepos = new OrderRepository(dbConn, dbConv, orderQuery);
            var addressRepos = new UserAddressRepository(dbConn, dbConv, addressQuery);
            cartItemRepos = new CartItemRepository(dbConn, dbConv, cartItemQuery);

            var userAddressVM = new UserAddressViewModel(addressRepos);
            var orderItemsVM = new OrderItemsViewModel(orderRepos);
            var paymentVM = new PaymentViewModel(userAddressVM, orderItemsVM);

            var cartItemsReceiver = new CartItemsReceiverAdapter(paymentVM);
            var cartVM = new CartViewModel(cartItemRepos, cartItemsReceiver, this);

            var productReceiver = new ProductReceiverAdapter(cartVM);
            var prodVM = new ProductsViewModel(prodRepos, productReceiver);
            
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
