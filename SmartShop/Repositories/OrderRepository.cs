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
            return dbConn.GetSingleObject(qry, dbConv.ToModel<Order>);
        }

        public decimal GetTotalPrice(string orderID)
        {
            var qry = query.GetTotalPrice(orderID);
            return dbConn.GetTotalDecimal<decimal>(qry);
        }
    }
}
