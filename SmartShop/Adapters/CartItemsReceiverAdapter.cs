using System;
using System.Collections.Generic;
using SmartShop.Models;
using SmartShop.ViewModels.UserControls;

namespace SmartShop.Adapters
{
    public class CartItemsReceiverAdapter : IReceiveCartItems
    {
        private readonly IReceiveOrder receiver;

        public CartItemsReceiverAdapter(IReceiveOrder receiver)
        {
            this.receiver = receiver;
        }

        public void Receive(List<CartItem> items)
        {
            var orderItems = convertToOrderItems(items);
            receiver.Receive(orderItems);
        }

        private List<OrderItem> convertToOrderItems(List<CartItem> items)
        {
            throw new NotImplementedException();
            return new List<OrderItem>();
        }
    }
}