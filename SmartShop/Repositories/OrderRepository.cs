using System.Collections.Generic;
using System.Data;
using SmartShop.Database;
using SmartShop.Models;
using SmartShop.Queries;

namespace SmartShop.Repositories
{
    public class OrderRepository : BaseRepository
    {
        private readonly OrderQuery query;
        
        public OrderRepository(DbConnection dbConn, DbConverter dbConv, OrderQuery query) : base(dbConn, dbConv)
        {
            this.query = query;
        }

        public bool Add(Order order)
        {
            var qry = query.Add(order);
            return dbConn.ExecuteNonQuery(qry);
        }

        public bool Delete(string id)
        {
            var qry = query.Delete(id);
            return dbConn.ExecuteNonQuery(qry);
        }

        public bool Update(Order order)
        {
            var qry = query.Update(order);
            return dbConn.ExecuteNonQuery(qry);
        }

        public Order SearchByID(string id)
        {
            var qry = query.SearchByID(id);
            using var reader = dbConn.ExecuteReader(qry);
            return dbConv.ToSingleObject<Order>(reader);
        }

        public decimal GetTotalPrice(string orderID)
        {
            var qry = query.GetTotalPrice(orderID);
            return dbConn.ExecuteScalar<decimal>(qry);
        }

        public string GetNewOrder(string userID)
        {
            var qry = query.GetNewOrder(userID);
            var result = dbConn.ExecuteScalar<string>(qry);
            return result;
        }

        public bool Pay(string orderID, out string notification)
        {
            var qry = query.Pay(orderID, out var notificationParameter);
            var result = dbConn.ExecuteNonQuery(qry);
            notification = notificationParameter?.Value?.ToString();
            return result;
        }

        public List<OrderItem> GetOrderItems(string orderID)
        {
            throw new System.NotImplementedException();
        }
    }
}