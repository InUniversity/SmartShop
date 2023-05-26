using SmartShop.Models;
using SmartShop.Database;
using SmartShop.Queries;
using System;
using System.Windows.Documents;
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

        public bool Add(CartItem item)
        {
            var qry = query.Add(item);
            return dbConn.ExecuteNonQuery(qry);
        }

        public bool Delete(string id)
        {
            var qry = query.Delete(id);
            return dbConn.ExecuteNonQuery(qry);
        }

        public bool Update(CartItem item)
        {
            var qry = query.Update(item);
            return dbConn.ExecuteNonQuery(qry);
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
    }
}
