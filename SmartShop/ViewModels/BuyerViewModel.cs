using System.Windows.Controls;
using System.Windows.Input;
using SmartShop.ViewModels.Base;
using SmartShop.Views.UserControls;

namespace SmartShop.ViewModels
{
    public class BuyerViewModel : BaseViewModel, INavigateView
    {
        private ContentControl currentChildView;
        public ContentControl CurrentChildView { get => currentChildView; set { currentChildView = value; OnPropertyChanged(); } }

        private ProductsUC productsView;
        private CartUC cartView;
        
        public ICommand MoveToProductsViewCommand { get; private set; }
        public ICommand MoveToCartViewCommand { get; private set; }

        public BuyerViewModel(ProductsUC productsView, CartUC cartView)
        {
            this.productsView = productsView;
            this.cartView = cartView;
            MoveToProductsView();
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
