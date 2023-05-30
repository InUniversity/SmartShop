using SmartShop.ViewModels.Base;
using System.Linq;
using System.Windows.Input;
using SmartShop.Models;
using SmartShop.Repositories;
using System.Collections.Generic;
using System.Windows;

namespace SmartShop.ViewModels.UserControls
{
    public interface IReceiveCartItem
    {
        void Receive(CartItemView itemView);
    }
    
    public class CartViewModel : BaseViewModel, IReceiveCartItem, ILoadView
    {
        private List<CartItemView> items;
        public List<CartItemView> Items { get => items; set { items = value; OnPropertyChanged(); } }

        private int totalQuantity;
        public int TotalQuantity { get => totalQuantity; set { totalQuantity = value; OnPropertyChanged(); } }

        private decimal curWalletBalance;
        public decimal CurWalletBalance { get => curWalletBalance; set { curWalletBalance = value; OnPropertyChanged(); } }

        private decimal totalPrice;
        public decimal TotalPrice { get => totalPrice; set { totalPrice = value; OnPropertyChanged(); } }
        
        public ICommand PlusSelQtyProdCommand { get; private set; }
        public ICommand MinusSelQtyProdCommand { get; private set; }
        public ICommand PayCommand { get; private set; }

        private readonly CartItemRepository cartItemRepos;
        private IReceiveCartItems paymentIns;
        private INavigateView navView;

        private User user = CurrentUser.Ins.Usr;

        public CartViewModel(CartItemRepository cartItemRepos, IReceiveCartItems paymentIns, INavigateView navView)
        {
            this.cartItemRepos = cartItemRepos;
            this.paymentIns = paymentIns;
            this.navView = navView;
            Load();
            SetCommands();
        }

        public void Load()
        {
            LoadCartItems();
        }

        private void LoadCartItems()
        {
            Items = cartItemRepos.SearchByUserID(user.ID);
            TotalQuantity = cartItemRepos.GetTotalQuantity(user.ID);
            CurWalletBalance = user.WalletBalance;
            TotalPrice = cartItemRepos.GetTotalPrice(user.ID);
        }

        private void SetCommands()
        {
            PlusSelQtyProdCommand = new RelayCommand<CartItemView>(ExecutePlusSelQtyProd);
            MinusSelQtyProdCommand = new RelayCommand<CartItemView>(ExecuteMinusSelQtyProd);
            PayCommand = new RelayCommand<object>(ExecutePay);
        }

        private void ExecutePlusSelQtyProd(CartItemView item)
        {
            item.Quantity += 1;
            Update(item);
        }

        private void ExecuteMinusSelQtyProd(CartItemView item)
        {
            item.Quantity -= 1;
            Update(item);
        }

        private void Update(CartItem item)
        {
            cartItemRepos.AddOrUpdate(item, out var notification);
            MessageBox.Show(notification, "Đã hoàn tác", MessageBoxButton.OK);
            Load();
        }

        private void ExecutePay(object obj)
        {
            paymentIns.Receive( items.ToList() );
            navView.MoveToPaymentView();
        }

        public void Receive(CartItemView itemView)
        {
            cartItemRepos.AddOrUpdate(itemView, out var notification);
            MessageBox.Show(notification, "Đã hoàn tác", MessageBoxButton.OK);
            Load();
        }
    }
}