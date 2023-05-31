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
                nameof(UserView) => new ToUserView(),
                nameof(CartItem) => new ToCartItem(),
                nameof(Category) => new ToCategory(),
                nameof(Order) => new ToOrder(),
                nameof(OrderItem) => new ToOrderItem(),
                nameof(OrderStatus) => new ToOrderStatus(),
                nameof(Product) => new ToProduct(),
                nameof(User) => new ToUser(),
                nameof(UserAddress) => new ToUserAddress(),
                nameof(UserRole) => new ToUserRole(),
                nameof(ProductView) => new ToProductView(),
                nameof(CartItemView) => new ToCartItemView(),
                _ => throw new NotSupportedException("ConvModelFactory: Can't implement type")
            };
        }
    }
}