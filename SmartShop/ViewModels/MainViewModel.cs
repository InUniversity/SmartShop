using System.Windows.Controls;
using System.Windows.Input;
using SmartShop.Adapters;
using SmartShop.ConvertToModel;
using SmartShop.Database;
using SmartShop.Queries;
using SmartShop.Repositories;
using SmartShop.ViewModels.Base;
using SmartShop.ViewModels.UserControls;
using SmartShop.Views.UserControls;

namespace SmartShop.ViewModels
{
    public class MainViewModel : BaseViewModel, INavigateView, ILoadView
    {
        private ContentControl currentChildView;
        public ContentControl CurrentChildView { get => currentChildView; set { currentChildView = value; OnPropertyChanged(); } }

        public int cartQuantity;
        public int CartQuantity { get => cartQuantity; set { cartQuantity = value; OnPropertyChanged(); } }
        
        public ICommand MoveToProductsViewCommand { get; private set; }
        public ICommand MoveToCartViewCommand { get; private set; }
        public ICommand MoveToEditProdsViewCommand { get; private set; }

        private readonly DbConnection dbConn;
        private CartItemRepository cartItemRepos;

        private ProductsUC prodsView;
        private ProdDetailUC prodDetailView;
        private CartUC cartView;
        private PaymentUC paymentView;
        private EditProdsUC editProdsUC;

        public MainViewModel(DbConnection dbConn)
        {
            this.dbConn = dbConn;
            ConfigDependencies();
            Load();
            MoveToProductsView();
            SetCommands();
        }

        private void ConfigDependencies()
        {
            var convModelFactory = new ConvModelFactory();
            var dbConv = new DbConverter(convModelFactory);

            var prodQuery = new ProductQuery();
            var orderQuery = new OrderQuery();
            var addressQuery = new UserAddressQuery();
            var cartItemQuery = new CartItemQuery();
            var ctgQuery = new CategoryQuery();
            
            var prodRepos = new ProductRepository(dbConn, dbConv, prodQuery);
            var orderRepos = new OrderRepository(dbConn, dbConv, orderQuery);
            var addressRepos = new UserAddressRepository(dbConn, dbConv, addressQuery);
            cartItemRepos = new CartItemRepository(dbConn, dbConv, cartItemQuery);
            var ctgRepos = new CategoryRepository(dbConn, dbConv, ctgQuery);

            var userAddressVM = new UserAddressViewModel(addressRepos);
            var orderItemsVM = new OrderViewModel(orderRepos);
            var paymentVM = new PaymentViewModel(userAddressVM, orderItemsVM, orderRepos);

            var cartVM = new CartViewModel(cartItemRepos, orderRepos,this, paymentVM);

            var productReceiver = new ProductReceiverAdapter(cartVM, cartItemRepos);
            var prodDetailVM = new ProdDetailViewModel(productReceiver, this);
            
            var prodVM = new ProductsViewModel(prodRepos, prodDetailVM, this);
            
            var editProdVM = new EditProdsViewModel(prodRepos, ctgRepos);
            
            InitViewComponents(paymentVM, cartVM, prodVM, prodDetailVM, editProdVM);
        }

        private void InitViewComponents(
            PaymentViewModel paymentVM, 
            CartViewModel cartVM, 
            ProductsViewModel prodVM, 
            ProdDetailViewModel prodDetailVM,
            EditProdsViewModel editProdVM)
        {
            paymentView = new PaymentUC { DataContext = paymentVM };
            cartView = new CartUC { DataContext = cartVM };
            prodsView = new ProductsUC { DataContext = prodVM };
            prodDetailView = new ProdDetailUC { DataContext = prodDetailVM };
            editProdsUC = new EditProdsUC { DataContext = editProdVM };
        }

        private void SetCommands()
        {
            MoveToProductsViewCommand = new RelayCommand<object>(_ => MoveToProductsView());
            MoveToCartViewCommand = new RelayCommand<object>(_ => MoveToCartView());
            MoveToEditProdsViewCommand = new RelayCommand<object>(_ => MoveToEditProdsView());
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

        public void MoveToProdDetailView()
        {
            CurrentChildView = prodDetailView;
        }
        
        public void MoveToEditProdsView()
        {
            CurrentChildView = editProdsUC;
        }

        public void Load()
        {
            
            CartQuantity = cartItemRepos.GetTotalQuantity(CurrentDb.Ins.Usr.ID); 
        }

        private void Refresh(
            CartViewModel cartVM, 
            ProductsViewModel prodVM, 
            EditProdsViewModel editProdVM)
        {
            cartVM.Load();
            prodVM.Load();
            editProdVM.Load();
        }
    }
}