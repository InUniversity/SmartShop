using System;
using SmartShop.Models;
using SmartShop.ViewModels.UserControls;

namespace SmartShop.Adapters
{
    public class ProductReceiverAdapter : IReceiveProduct
    {
        private readonly IReceiveCartItem receiver;

        public ProductReceiverAdapter(IReceiveCartItem receiver)
        {
            this.receiver = receiver;
        }

        public void Receive(ProductView prodView)
        {
            var item = ConvertToCartItem(prodView);
            receiver.Receive(item);
        }

        private CartItemView ConvertToCartItem(ProductView prodView)
        {
            throw new NotImplementedException();
            return new CartItemView();
        }
    }
}