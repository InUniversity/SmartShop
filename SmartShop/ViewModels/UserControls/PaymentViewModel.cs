using System.Windows;
using System.Windows.Input;
using SmartShop.Repositories;
using SmartShop.ViewModels.Base;

namespace SmartShop.ViewModels.UserControls
{
    public interface IReceiveOrder
    {
        void Receive(string orderID);
    }
    
    public class PaymentViewModel : BaseViewModel, IReceiveOrder
    {
        public ICommand PayCommand { get; private set; }

        public UserAddressViewModel UserAddressVM { get; }
        public OrderViewModel OrderItemsVM { get; }

        private readonly OrderRepository orderRepos;

        public string CurOrderID { get; set; }

        public PaymentViewModel(UserAddressViewModel userAddressVM, OrderViewModel orderItemsVM, OrderRepository orderRepos)
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
            orderRepos.Pay(CurOrderID, out var notification);
            if (string.IsNullOrEmpty(notification))
                MessageBox.Show(notification, "Đã hoàn tác", MessageBoxButton.OK);
        }

        public void Receive(string orderID)
        {
            var order = orderRepos.SearchByID(orderID);
            var orderItems = orderRepos.GetOrderItems(order.ID);
            OrderItemsVM.Receive(orderItems);
        }
    }
}