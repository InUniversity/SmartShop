using System.Data;
using System.Data.SqlClient;
using SmartShop.Models;
using SmartShop.Services;

namespace SmartShop.Queries
{
    public class CartItemQuery
    {
        public QueryService Add(CartItem item)
        {
            var query = new QueryService("sp_AddCartItem", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@CartItemID", item.ID),
                new SqlParameter("@UserID",item.UserID),
                new SqlParameter("@ProductID", item.ProdID),
                new SqlParameter("@Quantity", item.Quantity)
            };
            return query;
        }

        public QueryService Delete(string id)
        {
            var query = new QueryService("sp_DeleteCartItem", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@CartItemID", id)
            };
            return query;
        }

        public QueryService Update(CartItem item)
        {
            var query = new QueryService("sp_UpdateCartItem", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@CartItemID", item.ID),
                new SqlParameter("@NewUserID",item.UserID),
                new SqlParameter("@NewProductID", item.ProdID),
                new SqlParameter("@NewQuantity", item.Quantity)
            };
            return query;
        }

        public QueryService SearchByID(string id)
        {
            var query = new QueryService("sp_Ser_CartItems_By_ID", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@ID", id)
            };
            return query;
        }
    }
}