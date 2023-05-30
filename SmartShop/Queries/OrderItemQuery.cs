using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SmartShop.Models;
using SmartShop.Services;

namespace SmartShop.Queries
{
    public class OrderItemQuery
    {
        public QueryService Add(OrderItem orderitem)
        {
            var query = new QueryService("sp_AddOrderItem", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@OrderItemID", orderitem.ID),
                new SqlParameter("@OrderID", orderitem.OrderID),
                new SqlParameter("@ProductID", orderitem.ProdID),
                new SqlParameter("@Quantity", orderitem.Quantity)
            };
            return query;
        }

        public QueryService Delete(string id)
        {
            var query = new QueryService("sp_DeleteOrderItem", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@OrderItemID", id),
            };
            return query;
        }

        public QueryService Update(OrderItem orderitem)
        {
            var query = new QueryService("sp_UpdateOrderItem", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@OrderItemID", orderitem.ID),
                new SqlParameter("@NewOrderID", orderitem.OrderID),
                new SqlParameter("@NewProductID", orderitem.ProdID),
                new SqlParameter("@NewQuantity", orderitem.Quantity)
            };
            return query;
        }

        public QueryService SearchByID(string id)
        {
            var query = new QueryService("sp_Ser_OrderItem_By_ID_Index", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@ID", id)
            };
            return query;
        }
    }
}
