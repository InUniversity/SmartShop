using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartShop.Database;

namespace SmartShop.Repositories
{
    public class OrderStatusRepository : BaseRepository
    {
        public OrderStatusRepository(DbConnection dbConn) : base(dbConn)
        {

        }

        public bool Add(OrderStatu ordstatu)
        {
            string spCmd = $"sp_Add_OrderStatu";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@id", ordstatu.ID),
                new SqlParameter("@stName", ordstatu.StatusName)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Delete(string id)
        {
            string spCmd = $"sp_Delete_OrderStatu";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@id", id),
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Update(OrderStatu ordstatu)
        {
            string spCmd = $"sp_Update_Product";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@id", ordstatu.ID),
                new SqlParameter("@stName", ordstatu.StatusName)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }
        public OrderStatu SearchByID(string id)
        {
            string spCmd = $"sp_Ser_OrderStatu_By_ID";
            SqlParameter[] paras = new[]
            {
                new SqlParameter($"@{ordstID}", id),
            };
            return (OrderStatu)dbConn.GetSingleObject(spCmd, paras, Converter);
        }

        private OrderStatu Converter(SqlDataReader reader)
        {
            return new OrderStatu
            {
                ID = (string)reader[ordstID],
                StatusName = (string)reader[ordstname],
            };
        }
    }
}
