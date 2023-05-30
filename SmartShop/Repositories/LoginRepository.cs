using SmartShop.Database;
using SmartShop.Models;
using SmartShop.Queries;
using SmartShop.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SmartShop.Repositories
{
    public class LoginRepository : BaseRepository
    {
        private readonly LoginQuery query;

        public LoginRepository(DbConnection dbConn, DbConverter dbConv, LoginQuery query) : base(dbConn, dbConv)
        {
            this.query = query;
        }

        public UserAccount SearchAccount(string user, string pass)
        {
            var qry = query.SearchAccountUser(user, pass);
            using var reader = dbConn.ExecuteReader(qry);
            return dbConv.ToSingleObject<UserAccount>(reader);
        }


        public int? GetAuthorizedAccountID(string username, string pass)
        {
            UserAccount decentralization = SearchAccount(username, pass);
            return decentralization?.ID;
        }
    }
}

