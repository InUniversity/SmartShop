using System.Windows.Input;
using SmartShop.Models;
using SmartShop.ViewModels.Base;

namespace SmartShop.ViewModels.UserControls
{
    public interface IReceiveProduct
    {
        void Receive(Product prod);
    }
    
    public class ProdDetailViewModel : BaseViewModel, IReceiveProduct
    {
        private Product prod = new Product();

        public string ID { get => prod.ID; set { prod.ID = value; OnPropertyChanged(); } }
        public string ImgUrl { get => prod.ImgUrl; set { prod.ImgUrl = value; OnPropertyChanged(); } }
        public string Name { get => prod.Name; set { prod.Name = value; OnPropertyChanged(); } }
        public decimal Price { get => prod.Price; set { prod.Price = value; OnPropertyChanged(); } }
        public int RemainQuantity { get => prod.RemainQuantity; set { prod.RemainQuantity = value; OnPropertyChanged(); } }
        public string Desc { get => prod.Desc; set { prod.Desc = value; OnPropertyChanged(); } }
        public int SelectedQuantity { get => prod.SelectedQuantity; set { prod.SelectedQuantity = value; OnPropertyChanged(); } }
        public string CategoryName { get => prod.Category.Name; set { prod.Category.Name = value; OnPropertyChanged(); } }

        public ICommand PlusSelQtyProdCommand { get; private set; }
        public ICommand MinusSelQtyProdCommand { get; private set; }
        public ICommand AddToCartCommand { get; private set; }
        
        private readonly IReceiveProduct cartIns;

        public ProdDetailViewModel(IReceiveProduct cartIns)
        {
            this.cartIns = cartIns;
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
            if (RemainQuantity > RemainQuantity) return;
            RemainQuantity += 1;
        }

        private void ExecuteMinusSelQtyProd(object obj)
        {
            if (RemainQuantity < 1) return;
            RemainQuantity -= 1;
        }

        private void ExecuteAddToCard(object obj)
        {
            cartIns.Receive(prod);
        }

        public void Receive(Product prod)
        {
            this.prod = prod;
        }
    }
}