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

        public PaymentViewModel(UserAddressViewModel userAddressVM, OrderViewModel orderItemsVM, OrderRepository orderRepos)
        {
            UserAddressVM = userAddressVM;
            OrderItemsVM = orderItemsVM;
            this.orderRepos = orderRepos;
        }

        public void Receive(string orderID)
        {
            var orderItems = orderRepos.GetOrderItems(orderID);
            OrderItemsVM.Receive(orderItems);
        }
    }
}