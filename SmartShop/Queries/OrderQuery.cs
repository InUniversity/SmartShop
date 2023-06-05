using System;
using System.Data;
using System.Data.SqlClient;
using SmartShop.Services;

namespace SmartShop.Queries
{
    public class OrderQuery
    {
        public QueryService SearchByID(string id)
        {
            var query = new QueryService($"EXEC sp_Ser_Order_By_ID '{id}'", CommandType.Text);
            return query;
        }

        public QueryService SearchOrdersByUserID(string userID)
        {
            var query = new QueryService($"SELECT * FROM fn_SerOrdersByUserID('{userID}')", CommandType.Text);
            return query;
        }

        public QueryService GetTotalQuantity(string orderID)
        {
            var query = new QueryService($"SELECT dbo.fn_CalculateTotalQuantityOrder('{orderID}')", CommandType.Text);
            return query;
        }

        public QueryService GetTotalPrice(string orderID)
        {
            var query = new QueryService($"SELECT dbo.fn_CalculateTotalOrder('{orderID}')", CommandType.Text);
            return query;
        }

        public QueryService GetNewOrder(string userID)
        {
            var query = new QueryService($"SELECT dbo.fn_GenerateNewOrder('{userID}')", CommandType.Text);
            return query;
        }

        public QueryService Pay(string orderID, out SqlParameter notificationParameter)
        {
            notificationParameter = new SqlParameter("@Notification", SqlDbType.NVarChar, 1000);
            notificationParameter.Direction = ParameterDirection.Output;
            var query = new QueryService("sp_Pay", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@OrderID", orderID),
                notificationParameter
            };
            return query;
        }

        public QueryService GetOrderItems(string orderID)
        {
            var query = new QueryService($"SELECT * FROM dbo.fn_SerOrderItemsByOrderID('{orderID}')", CommandType.Text);
            return query;
        }

        public QueryService SearchByDateRange(DateTime start, DateTime end)
        {
            var query = new QueryService("sp_GetOrdersByDateRange", CommandType.StoredProcedure);
            query.Paras = new SqlParameter[]
            {
                new SqlParameter("@startDate", start) { SqlDbType = SqlDbType.DateTime },
                new SqlParameter("@endDate", end) { SqlDbType = SqlDbType.DateTime }
            };
            return query;
        }
    }
}