using System;
using System.Collections.Generic;
using SmartShop.Models;
using SmartShop.Repositories;
using SmartShop.ViewModels.UserControls;

namespace SmartShop.Adapters
{
    public class CartItemsReceiverAdapter : IReceiveCartItems
    {
        private readonly IReceiveOrderItems receiver;
        private readonly OrderRepository orderRepos;

        public CartItemsReceiverAdapter(IReceiveOrderItems receiver, OrderRepository orderRepos)
        {
            this.receiver = receiver;
            this.orderRepos = orderRepos;
        }

        public void Receive(List<CartItemView> itemsView)
        {
            var order = ConvertToOrderItems(itemsView);
            receiver.Receive(order);
        }

        private List<OrderItem> ConvertToOrderItems(List<CartItemView> items)
        {
            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (var item in items)
            {
                throw new NotImplementedException();
            }
            return orderItems;
        }
    }
}