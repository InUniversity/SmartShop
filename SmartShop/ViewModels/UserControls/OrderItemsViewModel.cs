using System.Collections.Generic;
using SmartShop.Models;
using SmartShop.Repositories;
using SmartShop.ViewModels.Base;

namespace SmartShop.ViewModels.UserControls
{
    public class OrderItemsItemsViewModel : BaseViewModel, IReceiveOrderItems
    {
        private List<OrderItem> orderItems = new List<OrderItem>(); 
        public List<OrderItem> OrderItems { get => orderItems; set { orderItems = value; OnPropertyChanged(); } }
        
        public decimal TotalPrice => orderRepos.GetTotalPrice(curOrderID);
        
        private readonly OrderRepository orderRepos;
        private string curOrderID;

        public OrderItemsItemsViewModel(OrderRepository orderRepos)
        {
            this.orderRepos = orderRepos;
        }

        public void Receive(List<OrderItem> orderItems)
        {
            OrderItems = orderItems;
        }
    }
}
