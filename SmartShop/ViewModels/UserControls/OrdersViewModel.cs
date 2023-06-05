using SmartShop.Database;
using SmartShop.Models;
using SmartShop.Repositories;
using SmartShop.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace SmartShop.ViewModels.UserControls
{
    public class OrdersViewModel : BaseViewModel
    {
        private List<Order> orders;
        public List<Order> Orders { get { return orders; } set { orders = value; OnPropertyChanged(); } }

        public Order SelOrder { get; set; }

        private DateTime startDate = DateTime.Now;
        public DateTime StartDate { get => startDate; set { startDate = value; SearchByDateRange(); OnPropertyChanged(); } } 

        private DateTime endDate = DateTime.Now;
        public DateTime EndDate { get => endDate; set { endDate = value; SearchByDateRange(); OnPropertyChanged(); } }

        public ICommand ShowDetailsOrderCommand { get; private set; }

        private readonly OrderRepository orderRepos;
        private readonly INavigateView mainIns;
        private readonly IReceiveOrder paymentIns;

        public OrdersViewModel(OrderRepository orderRepos, INavigateView mainIns, IReceiveOrder paymentIns)
        {
            this.orderRepos = orderRepos;
            this.mainIns = mainIns;
            this.paymentIns = paymentIns;
            Load();
            SetCommands();
        }

        private void SetCommands()
        {
            ShowDetailsOrderCommand = new RelayCommand<object>(ExecuteShowDetailsOrder);
        }

        private void ExecuteShowDetailsOrder(object obj)
        {
            paymentIns.Receive(obj as string);
            mainIns.MoveToPaymentView();
        }

        public void Load()
        {
            Orders = orderRepos.SearchOrdersByUserID(CurrentDb.Ins.Usr.ID);
            foreach (var order in Orders)
            {
                order.Items = orderRepos.GetOrderItems(order.ID);
            }
        }

        private void SearchByDateRange()
        {
            Orders = orderRepos.SearchByDateRange(StartDate, EndDate);
        }
    }
}
