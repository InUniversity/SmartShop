using System.Data;
using System.Data.SqlClient;
using SmartShop.Models;
using SmartShop.Services;

namespace SmartShop.Queries
{
    public class OrderQuery
    {
        public QueryService Add(Order order)
        {
            var query = new QueryService("sp_AddOrder", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@OrderID", order.ID),
                new SqlParameter("@UserID", order.UserID),
                new SqlParameter("@StatusID", order.StatusID),
                new SqlParameter("@OrderDate", order.Date)
            };
            return query;
        }

        public QueryService Delete(string id)
        {
            var query = new QueryService("sp_DeleteOrder", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@OrderID", id),
            };
            return query;
        }

        public QueryService Update(Order order)
        {
            var query = new QueryService("sp_UpdateOrder", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@OrderID", order.ID),
                new SqlParameter("@NewUserID", order.UserID),
                new SqlParameter("@NewStatusID", order.StatusID),
                new SqlParameter("@NewOrderDate", order.Date)
            };
            return query;
        }

        public QueryService SearchByID(string id)
        {
            var query = new QueryService("sp_Ser_Order_By_ID", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@ID", id)
            };
            return query;
        }

        public QueryService GetTotalPrice(string orderID)
        {
            var query = new QueryService($"SELECT dbo.fn_CalculateTotalOrder('{orderID}')", CommandType.Text);
            return query;
        }

        public QueryService GetNewOrder(string userID)
        {
            var query = new QueryService($"SELECT dbo.fn_GenerateOrderID('{userID}')", CommandType.Text);
            return query;
        }

        public QueryService Pay(string orderID, out SqlParameter notificationParameter)
        {
            notificationParameter = new SqlParameter("@Notification", SqlDbType.NVarChar, 1000);
            notificationParameter.Direction = ParameterDirection.Output;
            var query = new QueryService("sp_AddOrder", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@OrderID", orderID),
                notificationParameter
            };
            return query;
        }
    }
}