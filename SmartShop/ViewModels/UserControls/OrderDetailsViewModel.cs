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
    
    public class OrderDetailsViewModel : BaseViewModel, IReceiveOrder
    {
        public ICommand PayCommand { get; private set; }

        public UserAddressViewModel UserAddressVM { get; }
        public OrderViewModel OrderItemsVM { get; }

        public ICommand BackToOrderViewCommand { get; private set; }

        private readonly OrderRepository orderRepos;

        public OrderDetailsViewModel(UserAddressViewModel userAddressVM, OrderViewModel orderItemsVM, OrderRepository orderRepos, INavigateView mainIns)
        {
            UserAddressVM = userAddressVM;
            OrderItemsVM = orderItemsVM;
            this.orderRepos = orderRepos;
            BackToOrderViewCommand = new RelayCommand<object>(_ => mainIns.MoveToOrderView());
        }

        public void Receive(string orderID)
        {
            var orderItems = orderRepos.GetOrderItems(orderID);
            OrderItemsVM.Receive(orderItems);
        }
    }
}