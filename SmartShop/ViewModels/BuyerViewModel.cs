using System.Windows.Controls;
using System.Windows.Input;
using SmartShop.ViewModels.Base;
using SmartShop.ViewModels.UserControls;
using SmartShop.Views.UserControls;

namespace SmartShop.ViewModels
{
    public class BuyerViewModel : BaseViewModel, INavigateView
    {
        private ContentControl currentChildView;
        public ContentControl CurrentChildView { get => currentChildView; set { currentChildView = value; OnPropertyChanged(); } }

        private ProductsViewModel productsVM = new ProductsViewModel();
        private ProductsUC productsView;
        private CartViewModel cartVM = new CartViewModel();
        private CartUC cartView;
        
        public ICommand MoveToProductsViewCommand { get; private set; }
        public ICommand MoveToCartViewCommand { get; private set; }

        public BuyerViewModel()
        {
            productsView = new ProductsUC {DataContext = productsVM};
            cartView = new CartUC {DataContext = cartVM};
            CurrentChildView = productsView;
            SetCommands();
        }

        private void SetCommands()
        {
            MoveToProductsViewCommand = new RelayCommand<object>(_ => MoveToProductsView());
            MoveToCartViewCommand = new RelayCommand<object>(_ => MoveToCartView());
        }

        public void MoveToProductsView()
        {
            CurrentChildView = productsView;
        }

        public void MoveToCartView()
        {
            CurrentChildView = cartView;
        }
    }
}
