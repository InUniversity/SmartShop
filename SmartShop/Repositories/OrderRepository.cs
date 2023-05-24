using System;
using System.Data.SqlClient;
using SmartShop.Database;
using SmartShop.Models;

namespace SmartShop.Repositories
{
    public class OrderRepository : BaseRepository
    {
        public OrderRepository(DbConnection dbConn) : base(dbConn)
        {

        }

        public bool Add(Order order)
        {
            string spCmd = $"sp_AddOrder";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@OrderID", order.ID),
                new SqlParameter("@UserID", order.UserID),
                new SqlParameter("@OrderStatusID", order.StatusID),
                new SqlParameter("@OrderDate", order.Date)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Delete(string id)
        {
            string spCmd = $"sp_DeleteOrder";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@OrderID", id),
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Update(Order order)
        {
            string spCmd = $"sp_UpdateOrder";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@OrderID", order.ID),
                new SqlParameter("@NewUserID", order.UserID),
                new SqlParameter("@NewOrderStatusID", order.StatusID),
                new SqlParameter("@NewOrderDate", order.Date)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public Order SearchByID(string id)
        {
            string spCmd = $"sp_Ser_Order_By_ID";
            SqlParameter[] paras = new[]
            {
                new SqlParameter($"@{ordID}", id),
            };
            return (Order)dbConn.GetSingleObject(spCmd, paras, Converter);
        }

        public decimal GetTotalPrice(string orderID)
        {
            string fnCmd = "SELECT dbo.fn_CalculateTotalOrder(@OrderID)";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@OrderID", orderID)
            };
            return dbConn.GetTotalDecimal<decimal>(fnCmd, paras);
        }

        private Order Converter(SqlDataReader reader)
        {
            return new Order
            {
                ID = (string)reader[ordID],
                UserID = (string)reader[orduID],
                StatusID = (string)reader[ordSttusID],
                Date = (DateTime)reader[ordDate]
            };
        }
    }
}
