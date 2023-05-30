using SmartShop.Models;
using SmartShop.Database;
using SmartShop.Queries;
using System.Collections.Generic;

namespace SmartShop.Repositories
{
    public class CartItemRepository : BaseRepository
    {
        private readonly CartItemQuery query;
        
        public CartItemRepository(DbConnection dbConn, DbConverter dbConv, CartItemQuery query) : base(dbConn, dbConv)
        {
            this.query = query;
        }

        public bool AddOrUpdate(CartItem item, out string notification)
        {
            var qry = query.AddOrUpdate(item, out var notificationParameter);
            var result = dbConn.ExecuteNonQuery(qry);
            notification = notificationParameter?.Value?.ToString();
            return result;
        }

        public bool Delete(string id)
        {
            var qry = query.Delete(id);
            return dbConn.ExecuteNonQuery(qry);
        }

        public bool Update(CartItem item, out string notification)
        {
            var qry = query.Update(item, out var notificationParameter);
            var result =  dbConn.ExecuteNonQuery(qry);
            notification = notificationParameter?.Value?.ToString();
            return result;
        }

        public CartItemView SearchByID(string id)
        {
            var qry = query.SearchByID(id);
            using var reader = dbConn.ExecuteReader(qry);
            return dbConv.ToSingleObject<CartItemView>(reader);
        }

        public List<CartItemView> SearchByUserID(string userID)
        {
            var qry = query.SearchByUserID(userID);
            using var reader = dbConn.ExecuteReader(qry);
            return dbConv.ToList<CartItemView>(reader);
        }

        public int GetTotalQuantity(string userID)
        {
            var qry = query.GetTotalQuantity(userID);
            return dbConn.ExecuteScalar<int>(qry);
        }

        public decimal GetTotalPrice(string userID)
        {
            var qry = query.GetTotalPrice(userID);
            return dbConn.ExecuteScalar<decimal>(qry);
        }

        public string GenerateNewID()
        {
            var qry = query.GenerateNewID();
            return dbConn.ExecuteScalar<string>(qry);
        }
    }
}