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

        public void Receive(List<CartItemView> itemsView)
        {
            var order = convertToOrderItems(itemsView);
            receiver.Receive(order);
        }

        private Order convertToOrderItems(List<CartItemView> items)
        {
            throw new NotImplementedException();
            return new Order();
        }
    }
}