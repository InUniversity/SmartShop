using SmartShop.Database;
using SmartShop.Models;
using SmartShop.Repositories;
using SmartShop.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace SmartShop.ViewModels.UserControls
{
    public class OrdersViewModel : BaseViewModel, ILoadView
    {
        private List<Order> orders;
        public List<Order> Orders { get { return orders; } set { orders = value; OnPropertyChanged(); } }

        public Order SelOrder { get; set; }

        private DateTime startDate = new DateTime(2000, 1, 1);
        public DateTime StartDate { get => startDate; set { startDate = value; Load(); OnPropertyChanged(); } } 

        private DateTime endDate = DateTime.Now;
        public DateTime EndDate { get => endDate; set { endDate = value; Load(); OnPropertyChanged(); } }

        public ICommand ShowDetailsOrderCommand { get; private set; }

        private readonly OrderRepository orderRepos;
        private readonly INavigateView mainIns;
        private readonly IReceiveOrder ordDetailsIns;

        public OrdersViewModel(OrderRepository orderRepos, INavigateView mainIns, IReceiveOrder ordDetailsIns)
        {
            this.orderRepos = orderRepos;
            this.mainIns = mainIns;
            this.ordDetailsIns = ordDetailsIns;
            Load();
            SetCommands();
        }

        private void SetCommands()
        {
            ShowDetailsOrderCommand = new RelayCommand<object>(ExecuteShowDetailsOrder);
        }

        private void ExecuteShowDetailsOrder(object obj)
        {
            ordDetailsIns.Receive(SelOrder?.ID);
            mainIns.MoveToPaymentView();
        }

        public void Load()
        {
            EndDate.AddDays(1);
            Orders = orderRepos.SearchByDateRange(CurrentDb.Ins.Usr.ID, StartDate, EndDate);
            foreach (var order in Orders)
            {
                string id = order?.ID;
                order.TotalQuantity = orderRepos.GetTotalQuantity(id);
                order.TotalPrice = orderRepos.GetTotalPrice(id);
                order.Items = orderRepos.GetOrderItems(id);
            }
            OnPropertyChanged(nameof(Order));
        }
    }
}
