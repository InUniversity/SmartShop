using System;
using System.Collections.Generic;
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

        private IReceiveOrder paymentIns;
        private INavigateView navView;

        public CartViewModel(IReceiveOrder paymentIns, INavigateView navView)
        {
            this.paymentIns = paymentIns;
            this.navView = navView;
            SetCommands();
        }

        private void SetCommands()
        {
            PayCommand = new RelayCommand<object>(ExecutePay);
        }

        private void ExecutePay(object obj)
        {
            // TODO
            throw new NotImplementedException();
            paymentIns.Receive(new List<OrderItem>());
            navView.MoveToPaymentView();
        }

        public void Receive(CartItem item)
        {
            Items.Add(item);
        }
    }
}