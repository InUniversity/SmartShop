using System.Windows.Input;
using SmartShop.Database;
using SmartShop.Models;
using SmartShop.Repositories;
using SmartShop.ViewModels.Base;

namespace SmartShop.ViewModels.UserControls
{
    public interface IReceiveOrder
    {
        void Receive(string orderID);
    }
    
    public class OrderDetailsViewModel : BaseViewModel, IReceiveOrder
    {
        public OrderViewModel OrderItemsVM { get; }

        public User CurUser => CurrentDb.Ins.Usr;

        public ICommand BackToOrderViewCommand { get; private set; }

        private readonly OrderRepository orderRepos;

        public OrderDetailsViewModel(OrderViewModel orderItemsVM, OrderRepository orderRepos, INavigateView mainIns)
        {
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