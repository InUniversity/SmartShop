using System.Windows.Input;
using SmartShop.Models;
using SmartShop.ViewModels.Base;

namespace SmartShop.ViewModels.UserControls
{
    public interface IReceiveProduct
    {
        void Receive(ProductView prodView);
    }
    
    public class ProdDetailViewModel : BaseViewModel, IReceiveProduct
    {
        private ProductView prodView = new ProductView();
        
        public string ID { get => prodView.ID; set { prodView.ID = value; OnPropertyChanged(); } }
        public string ImgUrl { get => prodView.ImgUrl; set { prodView.ImgUrl = value; OnPropertyChanged(); } }
        public string Name { get => prodView.Name; set { prodView.Name = value; OnPropertyChanged(); } }
        public decimal Price { get => prodView.Price; set { prodView.Price = value; OnPropertyChanged(); } }
        public int RemainQuantity { get => prodView.RemainQuantity; set { prodView.RemainQuantity = value; OnPropertyChanged(); } }
        public string Desc { get => prodView.Desc; set { prodView.Desc = value; OnPropertyChanged(); } }
        public int SelectedQuantity { get => prodView.SelectedQuantity; set { prodView.SelectedQuantity = value; OnPropertyChanged(); } }
        public string CategoryName { get => prodView.CategoryName; set { prodView.CategoryName = value; OnPropertyChanged(); } }

        public ICommand PlusSelQtyProdCommand { get; private set; }
        public ICommand MinusSelQtyProdCommand { get; private set; }
        public ICommand AddToCartCommand { get; private set; }
        
        private readonly IReceiveProduct cartIns;
        private readonly ILoadView mainIns;

        public ProdDetailViewModel(IReceiveProduct cartIns, ILoadView mainIns)
        {
            this.cartIns = cartIns;
            this.mainIns = mainIns;
            SetCommands();
        }
        
        private void SetCommands()
        {
            PlusSelQtyProdCommand = new RelayCommand<object>(ExecutePlusSelQtyProd);
            MinusSelQtyProdCommand = new RelayCommand<object>(ExecuteMinusSelQtyProd);
            AddToCartCommand = new RelayCommand<object>(ExecuteAddToCard);
        }

        private void ExecutePlusSelQtyProd(object obj)
        {
            SelectedQuantity += 1;
        }

        private void ExecuteMinusSelQtyProd(object obj)
        {
            SelectedQuantity -= 1;
        }

        private void ExecuteAddToCard(object obj)
        {
            cartIns.Receive(prodView);
            SelectedQuantity = 1;
            mainIns.Load();
        }

        public void Receive(ProductView prodView)
        {
            ID = prodView.ID;
            ImgUrl = prodView.ImgUrl;
            Name = prodView.Name; 
            Price = prodView.Price; 
            RemainQuantity = prodView.RemainQuantity; 
            Desc = prodView.Desc; 
            SelectedQuantity = prodView.SelectedQuantity; 
            CategoryName = prodView.CategoryName;
        }
    }
}