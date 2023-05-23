using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                new SqlParameter("@OrderDate", order.Date),
                new SqlParameter("@TotalPrice", order.TotalPrice)
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
            string spCmd = $"sp_uUpdateOrder111";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@OrderID", order.ID),
                new SqlParameter("@NewUserID", order.UserID),
                new SqlParameter("@NewOrderStatusID", order.StatusID),
                new SqlParameter("@NewOrderDate", order.Date),
                new SqlParameter("@NewTotalPrice", order.TotalPrice)
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

        private Order Converter(SqlDataReader reader)
        {
            return new Order
            {
                ID = (string)reader[ordID],
                UserID = (string)reader[orduID],
                StatusID = (string)reader[ordSttusID],
                Date = (DateTime)reader[ordDate],
                TotalPrice = reader.GetDecimal(reader.GetOrdinal(ordTtP)),
            };
        }
    }
}
