using SmartShop.Database;
using SmartShop.Models;
using SmartShop.Repositories;
using SmartShop.ViewModels.UserControls;

namespace SmartShop.Adapters
{
    public class ProductReceiverAdapter : IReceiveProduct
    {
        private readonly IReceiveCartItem receiver;
        private readonly CartItemRepository cartItemRepos;

        public ProductReceiverAdapter(IReceiveCartItem receiver, CartItemRepository cartItemRepos)
        {
            this.receiver = receiver;
            this.cartItemRepos = cartItemRepos;
        }

        public void Receive(ProductView prodView)
        {
            var item = ConvertToCartItem(prodView);
            receiver.Receive(item);
        }

        private CartItemView ConvertToCartItem(ProductView prodView)
        {
            var itemView = new CartItemView
            {
                ID = cartItemRepos.GenerateNewID(),
                UserID = CurrentDb.Ins.Usr.ID,
                ProdID = prodView.ID,
                Quantity = prodView.SelectedQuantity
            };
            return itemView;
        }
    }
}