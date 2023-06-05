using System;
using SmartShop.Models;

namespace SmartShop.ConvertToModel
{
    public class ConvModelFactory
    {
        public BaseConvModel Create(Type type)
        {
            return type.Name switch
            {
                nameof(CartItem) => new ToCartItem(),
                nameof(CartItemView) => new ToCartItemView(),
                nameof(Category) => new ToCategory(),
                nameof(Order) => new ToOrder(),
                nameof(OrderItem) => new ToOrderItem(),
                nameof(OrderItemView) => new ToOrderItemView(),
                nameof(Product) => new ToProduct(),
                nameof(User) => new ToUser(),
                nameof(ProductView) => new ToProductView(),
                _ => throw new NotSupportedException("ConvModelFactory: Can't implement type")
            };
        }
    }
}