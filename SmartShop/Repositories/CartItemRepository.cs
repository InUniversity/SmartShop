using SmartShop.Models;
using SmartShop.Database;
using SmartShop.Queries;
using System;

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

        public CartItem SearchByID(string id)
        {
            var qry = query.SearchByID(id);
            using var reader = dbConn.ExecuteReader(qry);
            return dbConv.ToSingleObject<CartItem>(reader);
        }

        public int GetTotalQuantity(string iD)
        {
            throw new NotImplementedException();
        }
    }
}
