using SmartShop.ViewModels.Base;
using System.Collections.Generic;
using System.Windows.Input;
using SmartShop.Models;
using SmartShop.Repositories;

namespace SmartShop.ViewModels.UserControls
{
    public class ProductsViewModel : BaseViewModel, ILoadView
    {
        private List<ProductView> prods;
        public List<ProductView> Prods { get => prods; set { prods = value; OnPropertyChanged(); } }

        private ProductView selectedProduct;
        public ProductView SelectedProduct { get => selectedProduct; set { selectedProduct = value; OnPropertyChanged(); } }
        
        private string textToSearch;
        public string TextToSearch { get => textToSearch; set { textToSearch = value; SearchByName(); OnPropertyChanged(); } }

        public ICommand RefreshCommand { get; private set; }
        public ICommand MoveProdDetailCommand { get; private set; }

        private readonly ProductRepository prodRepos;
        private readonly IReceiveProduct prodDetailVM;
        private readonly INavigateView navView;

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
            RefreshCommand = new RelayCommand<object>(_ => Load());
            MoveProdDetailCommand = new RelayCommand<object>(MoveProdDetail);
        }

        private void MoveProdDetail(object obj)
        {
            if (SelectedProduct == null) return;
            prodDetailVM.Receive(SelectedProduct);
            navView.MoveToProdDetailView();
        }
        
        private void SearchByName()
        {
            Prods = prodRepos.SearchByName(TextToSearch);
        }

        private void LoadProducts()
        {
            Prods = prodRepos.GetAll();
        }

        public void Load()
        {
            LoadProducts();
        }
    }
}
