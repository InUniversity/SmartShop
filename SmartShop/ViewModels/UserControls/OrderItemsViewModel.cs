using System.Collections.Generic;
using SmartShop.Models;
using SmartShop.Repositories;
using SmartShop.ViewModels.Base;

namespace SmartShop.ViewModels.UserControls
{
    public interface IReceiveOrderItems
    {
        void Receive(List<OrderItemView> items);
    }
    
    public class OrderViewModel : BaseViewModel, IReceiveOrderItems
    {
        private List<OrderItemView> orderItems = new List<OrderItemView>(); 
        public List<OrderItemView> OrderItems { get => orderItems; set { orderItems = value; OnPropertyChanged(); } }
        
        public decimal TotalPrice => orderRepos.GetTotalPrice(curOrderID);
        
        private readonly OrderRepository orderRepos;
        private string curOrderID = "";

        public OrderViewModel(OrderRepository orderRepos)
        {
            this.orderRepos = orderRepos;
        }

        public void Receive(List<OrderItemView> items)
        {
            OrderItems = items;
        }
    }
}
