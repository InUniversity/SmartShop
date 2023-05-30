using System.Collections.Generic;
using System.Windows.Input;
using SmartShop.Models;
using SmartShop.Repositories;
using SmartShop.ViewModels.Base;

namespace SmartShop.ViewModels.UserControls
{
    public interface IReceiveCartItems
    {
        void Receive(List<CartItemView> itemsView);
    }
    
    public interface IReceiveOrderItems
    {
        void Receive(List<OrderItem> orderItems);
    }
    
    public class PaymentViewModel : BaseViewModel, IReceiveOrderItems
    {
        public ICommand PayCommand { get; private set; }

        public UserAddressViewModel UserAddressVM { get; }
        public OrderItemsItemsViewModel OrderItemsVM { get; }

        private readonly OrderRepository orderRepos;

        private string curOrderID;

        public PaymentViewModel(UserAddressViewModel userAddressVM, OrderItemsItemsViewModel orderItemsVM, OrderRepository orderRepos)
        {
            UserAddressVM = userAddressVM;
            OrderItemsVM = orderItemsVM;
            this.orderRepos = orderRepos;
            SetCommands();
        }

        private void SetCommands()
        {
            PayCommand = new RelayCommand<object>(ExecutePay);
        }

        private void ExecutePay(object obj)
        {
            orderRepos.Pay(curOrderID);
        }

        public void Receive(List<OrderItem> orderItems)
        {
            var order = orderRepos.GetNewOrder(CurrentUser.Ins.Usr.ID);
            curOrderID = order.ID;
            OrderItemsVM.Receive(orderItems);
            foreach (var item in OrderItemsVM.OrderItems)
            {
                item.OrderID = curOrderID;
            }
        }
    }
}
