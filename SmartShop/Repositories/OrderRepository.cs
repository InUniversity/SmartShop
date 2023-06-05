using System;
using System.Collections.Generic;
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

        public Order SearchByID(string id)
        {
            var qry = query.SearchByID(id);
            using var reader = dbConn.ExecuteReader(qry);
            return dbConv.ToSingleObject<Order>(reader);
        }

        public List<Order> SearchOrdersByUserID(string userID) 
        { 
            var qry = query.SearchOrdersByUserID(userID);
            using var reader = dbConn.ExecuteReader(qry);
            return dbConv.ToList<Order>(reader);
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

        public string Pay(string orderID, out string notification)
        {
            var qry = query.Pay(orderID, out var notificationParameter);
            var result = dbConn.ExecuteScalar<string>(qry);
            notification = notificationParameter?.Value?.ToString();
            return result;
        }

        public List<OrderItem> GetOrderItems(string orderID)
        {
            var qry = query.GetOrderItems(orderID);
            using var reader = dbConn.ExecuteReader(qry);
            return dbConv.ToList<OrderItem>(reader);
        }

        public List<Order> SearchByDateRange(DateTime start, DateTime end)
        {
            var qry = query.SearchByDateRange(start, end);
            using var reader = dbConn.ExecuteReader(qry);
            return dbConv.ToList<Order>(reader);
        }
    }
}