using SmartShop.Database;
using SmartShop.Models;
using SmartShop.Queries;

namespace SmartShop.Repositories
{
    public class OrderStatusRepository :BaseRepository
    {
        private readonly OrderStatusQuery query;
        
        public OrderStatusRepository(DbConnection dbConn, DbConverter dbConv, OrderStatusQuery query) 
            : base(dbConn, dbConv)
        {
            this.query = query;
        }

        public bool Add(OrderStatus ordstatu)
        {
            var qry = query.Add(ordstatu);
            return dbConn.ExecuteNonQuery(qry);
        }

        public bool Delete(string id)
        {
            var qry = query.Delete(id);
            return dbConn.ExecuteNonQuery(qry);
        }

        public bool Update(OrderStatus ordstatu)
        {
            var qry = query.Update(ordstatu);
            return dbConn.ExecuteNonQuery(qry);
        }
        
        public OrderStatus SearchByID(string id)
        {
            var qry = query.SearchByID(id);
            return dbConn.GetSingleObject(qry, dbConv.ToModel<OrderStatus>);
        }
    }
}
