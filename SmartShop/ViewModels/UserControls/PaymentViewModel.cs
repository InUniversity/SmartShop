using System;
using System.Collections.Generic;
using System.Windows.Input;
using SmartShop.Models;
using SmartShop.ViewModels.Base;

namespace SmartShop.ViewModels.UserControls
{
    public interface IReceiveCartItems
    {
        void Receive(List<CartItemView> itemsView);
    }
    
    public interface IReceiveOrder
    {
        void Receive(Order order);
    }
    
    public class PaymentViewModel : BaseViewModel, IReceiveOrder
    {
        public ICommand PayCommand { get; private set; }

        public UserAddressViewModel UserAddressVM { get; }
        public OrderItemsViewModel OrderItemsVM { get; }

        public PaymentViewModel(UserAddressViewModel userAddressVM, OrderItemsViewModel orderItemsVM)
        {
            UserAddressVM = userAddressVM;
            OrderItemsVM = orderItemsVM;
            SetCommands();
        }

        private void SetCommands()
        {
            PayCommand = new RelayCommand<object>(ExecutePay);
        }

        private void ExecutePay(object obj)
        {
            throw new NotImplementedException();
        }

        public void Receive(Order order)
        {
            OrderItemsVM.Receive(order);
        }
    }
}
