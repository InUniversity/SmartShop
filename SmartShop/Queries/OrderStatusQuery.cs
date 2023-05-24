using System.Data;
using System.Data.SqlClient;
using SmartShop.Models;
using SmartShop.Services;

namespace SmartShop.Queries
{
    public class OrderStatusQuery
    {
        public QueryService Add(OrderStatus ordstatu)
        {
            var query = new QueryService("sp_AddOrderStatus", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@StatusID", ordstatu.ID),
                new SqlParameter("@StatusName", ordstatu.Name)
            };
            return query;
        }

        public QueryService Delete(string id)
        {
            var query = new QueryService("sp_DeleteOrderStatus", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@StatusID", id)
            };
            return query;
        }

        public QueryService Update(OrderStatus ordstatu)
        {
            var query = new QueryService("sp_UpdateOrderStatus", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@StatusID", ordstatu.ID),
                new SqlParameter("@NewStatusName", ordstatu.Name)
            };
            return query;
        }
        
        public QueryService SearchByID(string id)
        {
            var query = new QueryService("sp_Ser_OrderStatus_By_ID", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@ID", id)
            };
            return query;
        }
    }
}