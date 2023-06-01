using System.Collections.Generic;
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

        public User Login(string user, string pass)
        {
            var qry = query.Login(user, pass);
            using var reader = dbConn.ExecuteReader(qry);
            var acc =  dbConv.ToList<User>(reader);
            return ((acc != null && acc.Count > 0) ? acc[0] : null);
        }

        public string CheckLogin(string user,string pass)
        {
            var qry = query.CheckLogin(user, pass);
            return dbConn.ExecuteScalar<string>(qry);
        }
    }
}

