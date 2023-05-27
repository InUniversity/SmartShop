using System.Collections.Generic;
using SmartShop.Database;
using SmartShop.Models;
using SmartShop.Queries;

namespace SmartShop.Repositories
{
    public class CategoryRepository : BaseRepository
    {
        private readonly CategoryQuery query;

        public CategoryRepository(DbConnection dbConn, DbConverter dbConv, CategoryQuery query) : base(dbConn, dbConv)
        {
            this.query = query;
        }

        public List<Category> GetAll()
        {
            var qry = query.GetAll();
            using var reader = dbConn.ExecuteReader(qry);
            return dbConv.ToList<Category>(reader);
        }
    }
}