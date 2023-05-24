using SmartShop.Database;
using SmartShop.Models;
using SmartShop.Queries;

namespace SmartShop.Repositories
{
    public class UserRepository :BaseRepository
    {
        private readonly UserQuery query;
        
        public UserRepository(DbConnection dbConn, DbConverter dbConv, UserQuery query) : base(dbConn, dbConv)
        {
            this.query = query;
        }

        public bool Add(User user)
        {
            var qry = query.Add(user);
            return dbConn.ExecuteNonQuery(qry);
        }

        public bool Delete(string id)
        {
            var qry = query.Delete(id);
            return dbConn.ExecuteNonQuery(qry);
        }

        public bool Update(User user)
        {
            var qry = query.Update(user);
            return dbConn.ExecuteNonQuery(qry);
        }

        public User SearchByID(string id)
        {
            var qry = query.SearchByID(id);
            return dbConn.GetSingleObject(qry, dbConv.ToModel<User>);
        }
    }
}
