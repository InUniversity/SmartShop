using SmartShop.Database;
using SmartShop.Models;
using System.Collections.Generic;
using SmartShop.Queries;
using System.Runtime.InteropServices;

namespace SmartShop.Repositories
{
    public class ProductRepository : BaseRepository
    {
        private readonly ProductQuery query;
        
        public ProductRepository(DbConnection dbConn, DbConverter dbConv, ProductQuery query) : base(dbConn, dbConv)
        {
            this.query = query;
        }

        public bool Add(Product prod, out string notification)
        {
            var qry = query.Add(prod, out var notificationParameter);
            var result = dbConn.ExecuteNonQuery(qry);
            notification = notificationParameter?.Value?.ToString();
            return result;
        }

        public bool Delete(string id, out string notification)
        {
            var qry = query.Delete(id, out var notificationParameter);
            var result = dbConn.ExecuteNonQuery(qry);
            notification = notificationParameter?.Value?.ToString();
            return result;
        }

        public bool Update(Product prod, out string notification)
        {
            var qry = query.Update(prod, out var notificationParameter);
            var result = dbConn.ExecuteNonQuery(qry);
            notification = notificationParameter?.Value?.ToString();
            return result;
        }

        public ProductView SearchByID(string id)
        {
            var qry = query.SearchByID(id);
            using var reader = dbConn.ExecuteReader(qry);
            return dbConv.ToSingleObject<ProductView>(reader); 
        }
        
        public List<ProductView> GetAll()
        {
            var qry = query.GetAll();
            using var reader = dbConn.ExecuteReader(qry);
            return dbConv.ToList<ProductView>(reader);
        }

        public List<ProductView> SearchByName(string prodName)
        {
            var qry = query.SearchByName(prodName);
            using var reader = dbConn.ExecuteReader(qry);
            return dbConv.ToList<ProductView>(reader);
        }

        public string GetNewID()
        {
            var qry = query.GetNewID();
            return dbConn.ExecuteScalar<string>(qry);
        }
    }
}
