using SmartShop.ViewModels.Base;
using System.Collections.Generic;
using System.Windows.Input;
using SmartShop.Models;
using SmartShop.Repositories;

namespace SmartShop.ViewModels.UserControls
{
    public class ProductsViewModel : BaseViewModel
    {
        private List<ProductView> prods;
        public List<ProductView> Prods { get => prods; set { prods = value; OnPropertyChanged(); } }

        private ProductView selectedProduct;
        public ProductView SelectedProduct { get => selectedProduct; set { selectedProduct = value; OnPropertyChanged(); } }

        public ICommand MoveProdDetailCommand { get; private set; }

        private readonly ProductRepository prodRepos;
        private readonly IReceiveProduct prodDetailVM;
        private readonly INavigateView navView;

        private User curUser = CurrentUser.Ins.Usr;

        public ProductsViewModel(ProductRepository prodRepos, IReceiveProduct prodDetailVM, INavigateView navView)
        {
            this.prodRepos = prodRepos;
            this.prodDetailVM = prodDetailVM;
            this.navView = navView;
            SetCommands();
            LoadProducts();
        }

        private void SetCommands()
        {
            MoveProdDetailCommand = new RelayCommand<object>(MoveProdDetail);
        }

        private void MoveProdDetail(object obj)
        {
            if (SelectedProduct == null) return;
            prodDetailVM.Receive(SelectedProduct);
            navView.MoveToProdDetailView();
        }

        private void LoadProducts()
        {
            Prods = prodRepos.GetAll();
        }
    }
}
