using SmartShop.Database;
using SmartShop.Models;
using System.Collections.Generic;
using System.Linq;
using SmartShop.Queries;

namespace SmartShop.Repositories
{
    public class ProductRepository : BaseRepository
    {
        private readonly ProductQuery query;
        
        public ProductRepository(DbConnection dbConn, DbConverter dbConv, ProductQuery query) : base(dbConn, dbConv)
        {
            this.query = query;
        }

        public bool Add(Product prod)
        {
            var qry = query.Add(prod);
            return dbConn.ExecuteNonQuery(qry);
        }

        public bool Delete(string id)
        {
            var qry = query.Delete(id);
            return dbConn.ExecuteNonQuery(qry);
        }

        public bool Update(Product prod)
        {
            var qry = query.Update(prod);
            return dbConn.ExecuteNonQuery(qry);
        }

        public Product SearchByID(string id)
        {
            var qry = query.SearchByID(id);
            return dbConn.GetSingleObject(qry, dbConv.ToModel<Product>); 
        }
        
        public List<Product> GetAll()
        {
            // Call function ?
            var qry = query.GetAll();
            return dbConn.GetEnumerable(qry, dbConv.ToModel<Product>).ToList();
        }
    }
}
