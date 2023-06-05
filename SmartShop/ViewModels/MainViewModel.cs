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
        public ICommand MoveToOrdersViewCommand { get; private set; }
        public ICommand MoveToEditProdsViewCommand { get; private set; }

        private readonly DbConnection dbConn;
        private readonly DbConverter dbConv;
        private CartItemRepository cartItemRepos;

        private ProductsUC prodsView;
        private ProdDetailUC prodDetailView;
        private CartUC cartView;
        private OrderDetailsUC ordDetailsView;
        private EditProdsUC editProdsView;
        private OrdersUC ordersView;

        public MainViewModel(DbConnection dbConn, DbConverter dbConv)
        {
            this.dbConn = dbConn;
            this.dbConv = dbConv;
            ConfigDependencies();
            Load();
            MoveToProductsView();
            SetCommands();
        }

        private void ConfigDependencies()
        {
            var prodQuery = new ProductQuery();
            var orderQuery = new OrderQuery();
            var cartItemQuery = new CartItemQuery();
            var ctgQuery = new CategoryQuery();
            
            var prodRepos = new ProductRepository(dbConn, dbConv, prodQuery);
            var orderRepos = new OrderRepository(dbConn, dbConv, orderQuery);
            cartItemRepos = new CartItemRepository(dbConn, dbConv, cartItemQuery);
            var ctgRepos = new CategoryRepository(dbConn, dbConv, ctgQuery);

            var orderItemsVM = new OrderViewModel(orderRepos);
            var ordDetailsVM = new OrderDetailsViewModel(orderItemsVM, orderRepos, this);

            var ordersVM = new OrdersViewModel(orderRepos, this, ordDetailsVM);

            var cartVM = new CartViewModel(cartItemRepos, orderRepos, this, ordDetailsVM, ordersVM);

            var productReceiver = new ProductReceiverAdapter(cartVM, cartItemRepos);
            var prodDetailVM = new ProdDetailViewModel(productReceiver, this);
            
            var prodVM = new ProductsViewModel(prodRepos, prodDetailVM, this);
            
            var editProdVM = new EditProdsViewModel(prodRepos, ctgRepos);

            
            InitViewComponents(ordDetailsVM, cartVM, prodVM, prodDetailVM, editProdVM, ordersVM);
        }

        private void InitViewComponents(
            OrderDetailsViewModel paymentVM, 
            CartViewModel cartVM, 
            ProductsViewModel prodVM, 
            ProdDetailViewModel prodDetailVM,
            EditProdsViewModel editProdVM,
            OrdersViewModel ordersVM)
        {
            ordDetailsView = new OrderDetailsUC { DataContext = paymentVM };
            cartView = new CartUC { DataContext = cartVM };
            prodsView = new ProductsUC { DataContext = prodVM };
            prodDetailView = new ProdDetailUC { DataContext = prodDetailVM };
            editProdsView = new EditProdsUC { DataContext = editProdVM };
            ordersView = new OrdersUC { DataContext = ordersVM };
        }

        private void SetCommands()
        {
            MoveToProductsViewCommand = new RelayCommand<object>(_ => MoveToProductsView());
            MoveToCartViewCommand = new RelayCommand<object>(_ => MoveToCartView());
            MoveToOrdersViewCommand = new RelayCommand<object>(_ => MoveToOrderView());
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
            CurrentChildView = ordDetailsView;
        }

        public void MoveToProdDetailView()
        {
            CurrentChildView = prodDetailView;
        }
        
        public void MoveToEditProdsView()
        {
            CurrentChildView = editProdsView;
        }

        public void MoveToOrderView()
        {
            CurrentChildView = ordersView;
        }

        public void Load()
        {
            CartQuantity = cartItemRepos.GetTotalQuantity(CurrentDb.Ins.Usr.ID); 
        }
    }
}