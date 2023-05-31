using System.Configuration;
using System.Data;
using SmartShop.Database;
using SmartShop.Models;
using SmartShop.Queries;

namespace SmartShop.Repositories
{
    public class LoginRepository : BaseRepository
    {
        private readonly LoginQuery query;

        public LoginRepository(DbConnection dbConn, DbConverter dbConv, LoginQuery query) : base(dbConn, dbConv)
        {
            this.query = query;
        }

        public UserView Login(string user, string pass, out string notification)
        {
            var qry = query.Login(user, pass, out var notificationParameter);
            using var reader = dbConn.ExecuteReader(qry);
            var usr = dbConv.ToSingleObject<UserView>(reader);
            notification = notificationParameter?.Value?.ToString();
            return usr;
        }
    }
}

