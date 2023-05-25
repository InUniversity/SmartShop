using SmartShop.Models;
using SmartShop.ViewModels.UserControls;

namespace SmartShop.Adapters
{
    public interface IReceiveProduct
    {
        void Receive(Product prod);
    }
    
    public class ProductReceiverAdapter : IReceiveProduct
    {
        private readonly IReceiveCartItem receiver;

        public ProductReceiverAdapter(IReceiveCartItem receiver)
        {
            this.receiver = receiver;
        }

        public void Receive(Product prod)
        {
            var item = ConvertToCartItem(prod);
            receiver.Receive(item);
        }

        private CartItem ConvertToCartItem(Product product)
        {
            return new CartItem();
        }
    }
}