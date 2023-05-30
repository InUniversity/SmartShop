using System.Data;
using System.Data.SqlClient;
using System.Linq;
using SmartShop.Models;
using SmartShop.Services;

namespace SmartShop.Queries
{
    public class CartItemQuery
    {
        public QueryService AddOrUpdate(CartItem item, out SqlParameter notificationParameter)
        {
            notificationParameter = new SqlParameter("@Notification", SqlDbType.NVarChar, 1000);
            notificationParameter.Direction = ParameterDirection.Output;
            var query = new QueryService("sp_AddOrUpdateCartItem", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@CartItemID", item.ID),
                new SqlParameter("@UserID",item.UserID),
                new SqlParameter("@ProductID", item.ProdID),
                new SqlParameter("@Quantity", item.Quantity),
                notificationParameter
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

        public QueryService Update(CartItem item, out SqlParameter notificationParameter)
        {
            notificationParameter = new SqlParameter("@Notification", SqlDbType.NVarChar, 1000);
            notificationParameter.Direction = ParameterDirection.Output;
            var query = new QueryService("sp_UpdateCartItem", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@CartItemID", item.ID),
                new SqlParameter("@UserID",item.UserID),
                new SqlParameter("@ProductID", item.ProdID),
                new SqlParameter("@Quantity", item.Quantity),
                notificationParameter
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

        public QueryService SearchByUserID(string userID)
        {
            var query = new QueryService($"SELECT * FROM dbo.fn_SerCartItemsByUserID('{userID}')", CommandType.Text);
            return query;
        }

        public QueryService GetTotalQuantity(string userID)
        {
            var query = new QueryService($"SELECT dbo.fn_GetQuantityProdInCart('{userID}')", CommandType.Text);
            return query;
        }

        public QueryService GetTotalPrice(string userID)
        {
            var query = new QueryService($"SELECT dbo.fn_GetPriceQuantityProdInCart('{userID}')", CommandType.Text);
            return query;
        }

        public QueryService GenerateNewID()
        {
            var query = new QueryService("SELECT dbo.fn_GenerateCartItemID()", CommandType.Text);
            return query;
        }
    }
}