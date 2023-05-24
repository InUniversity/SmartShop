using SmartShop.Database;
using SmartShop.Queries;

namespace SmartShop.Repositories
{
    public class UserRoleRepository : BaseRepository
    {
        private readonly UserRoleQuery query;
        
        public UserRoleRepository(DbConnection dbConn, DbConverter dbConv, UserRoleQuery query) : base(dbConn, dbConv)
        {
            this.query = query;
        }

        public bool Add(UserRole urole)
        {
            var qry = query.Add(urole);
            return dbConn.ExecuteNonQuery(qry);
        }

        public bool Delete(string id)
        {
            var qry = query.Delete(id);
            return dbConn.ExecuteNonQuery(qry);
        }

        public bool Update(UserRole urole)
        {
            var qry = query.Update(urole);
            return dbConn.ExecuteNonQuery(qry);
        }

        public UserRole SearchByID(string id)
        {
            var qry = query.SearchByID(id);
            return dbConn.GetSingleObject(qry, dbConv.ToModel<UserRole>);
        }
    }
}
