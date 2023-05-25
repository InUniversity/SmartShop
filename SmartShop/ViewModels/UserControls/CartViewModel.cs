using SmartShop.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using SmartShop.Models;
using SmartShop.Repositories;

namespace SmartShop.ViewModels.UserControls
{
    
    public interface IReceiveCartItem
    {
        void Receive(CartItem items);
    }
    
    public class CartViewModel : BaseViewModel, IReceiveCartItem
    {
        private ObservableCollection<CartItem> items;
        public ObservableCollection<CartItem> Items { get => items; set { items = value; OnPropertyChanged(); } }

        private int quantity;
        public int Quantity { get => quantity; private set { quantity = value; OnPropertyChanged(); } }
        
        public ICommand PayCommand { get; private set; }

        private string cartID = "";

        private readonly CartItemRepository cartItemRepos;
        private IReceiveCartItems paymentIns;
        private INavigateView navView;

        public CartViewModel(CartItemRepository cartItemRepos, IReceiveCartItems paymentIns, INavigateView navView)
        {
            this.cartItemRepos = cartItemRepos;
            this.paymentIns = paymentIns;
            this.navView = navView;
            LoadQuantity();
            SetCommands();
        }

        private void LoadQuantity()
        {
            Quantity = cartItemRepos.GetTotalQuantity(CurrentUser.Ins.Usr.ID);
        }

        private void SetCommands()
        {
            PayCommand = new RelayCommand<object>(ExecutePay);
        }

        private void ExecutePay(object obj)
        {
            paymentIns.Receive( items.ToList() );
            navView.MoveToPaymentView();
        }

        public void Receive(CartItem item)
        {
            Items.Add(item);
            LoadQuantity();
        }
    }
}