using System.Windows;
using System.Windows.Input;
using SmartShop.Database;
using SmartShop.Repositories;
using SmartShop.ViewModels.Base;

namespace SmartShop.ViewModels.UserControls
{
    public interface ICreateOrder
    {
        void Create();
    }
    
    public class PaymentViewModel : BaseViewModel, ICreateOrder
    {
        public ICommand PayCommand { get; private set; }

        public UserAddressViewModel UserAddressVM { get; }
        public OrderViewModel OrderItemsVM { get; }

        private readonly OrderRepository orderRepos;

        private string curOrderID;

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
            orderRepos.Pay(curOrderID, out var notification);
            if (string.IsNullOrEmpty(notification))
                MessageBox.Show(notification, "Đã hoàn tác", MessageBoxButton.OK);
        }

        public void Create()
        {
            curOrderID = orderRepos.GetNewOrder(CurrentDb.Ins.Usr?.ID);
            var order = orderRepos.SearchByID(curOrderID);
            
            var orderItems = orderRepos.GetOrderItems(order?.ID);
            OrderItemsVM.Receive(orderItems);
        }
    }
}