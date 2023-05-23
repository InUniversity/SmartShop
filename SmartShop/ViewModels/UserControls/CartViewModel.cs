using SmartShop.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SmartShop.Models;

namespace SmartShop.ViewModels.UserControls
{
    public interface IReceiveCartItem
    {
        void Receive(CartItem item);
    }
    
    public class CartViewModel : BaseViewModel, IReceiveCartItem
    {
        private ObservableCollection<CartItem> items;
        public ObservableCollection<CartItem> Items { get => items; set { items = value; OnPropertyChanged(); } }
        
        public ICommand PayCommand { get; private set; }

        private string cartID = "";


        public CartViewModel()
        {

        }

        public void Receive(CartItem item)
        {
            Items.Add(item);
        }
    }
}