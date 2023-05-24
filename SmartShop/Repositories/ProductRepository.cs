using SmartShop.Database;
using SmartShop.Models;
using System.Collections.Generic;
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
            using var reader = dbConn.ExecuteReader(qry);
            return dbConv.ToSingleObject<Product>(reader); 
        }
        
        public List<Product> GetAll()
        {
            // Call function ?
            var qry = query.GetAll();
            using var reader = dbConn.ExecuteReader(qry);
            return dbConv.ToList<Product>(reader);
        }
    }
}
