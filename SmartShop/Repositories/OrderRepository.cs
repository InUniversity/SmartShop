using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartShop.Database;
using System.Windows.Controls;

namespace SmartShop.Repositories
{
    public class OrderRepository : BaseRepository
    {
        public OrderRepository(DbConnection dbConn) : base(dbConn)
        {

        }

        public bool Add(Order order)
        {
            string spCmd = $"sp_Add_Order";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@id", order.ID),
                new SqlParameter("@uID", order.UserID),
                new SqlParameter("@odSttusID", order.OrderStatusID),
                new SqlParameter("@odDate", order.OrderDate),
                new SqlParameter("@ttPrice", order.TotalPrice)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Delete(string id)
        {
            string spCmd = $"sp_Delete_Order";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@id", id),
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Update(Order order)
        {
            string spCmd = $"sp_Update_Order";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@id", order.ID),
                new SqlParameter("@uID", order.UserID),
                new SqlParameter("@odSttusID", order.OrderStatusID),
                new SqlParameter("@odDate", order.OrderDate),
                new SqlParameter("@ttPrice", order.TotalPrice)
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
                OrderStatusID = (string)reader[ordSttusID],
                OrderDate = (DateTime)reader[ordDate],
                TotalPrice = reader.GetDecimal(reader.GetOrdinal(ordTtP)),
            };
        }
    }
}
