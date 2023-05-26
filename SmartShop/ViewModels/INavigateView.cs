namespace SmartShop.ViewModels
{
    public interface INavigateView
    {
        void MoveToProductsView();
        void MoveToCartView();
        void MoveToPaymentView();
        void MoveToProdDetailView();
    }
}