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
    public class OrderStatusRepository :BaseRepository
    {
        public OrderStatusRepository(DbConnection dbConn) : base(dbConn)
        {

        }

        public bool Add(OrderStatus ordstatu)
        {
            string spCmd = $"sp_AddOrderStatus";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@StatusID", ordstatu.ID),
                new SqlParameter("@StatusName", ordstatu.Name)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Delete(string id)
        {
            string spCmd = $"sp_DeleteOrderStatus";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@StatusID", id),
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Update(OrderStatus ordstatu)
        {
            string spCmd = $"sp_UpdateOrderStatus";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@StatusID", ordstatu.ID),
                new SqlParameter("@NewStatusName", ordstatu.Name)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }
        public OrderStatus SearchByID(string id)
        {
            string spCmd = $"sp_Ser_OrderStatus_By_ID";
            SqlParameter[] paras = new[]
            {
                new SqlParameter($"@{ordstID}", id),
            };
            return (OrderStatus)dbConn.GetSingleObject(spCmd, paras, Converter);
        }

        private OrderStatus Converter(SqlDataReader reader)
        {
            return new OrderStatus
            {
                ID = (string)reader[ordstID],
                Name = (string)reader[ordstname],
            };
        }
    }
}
