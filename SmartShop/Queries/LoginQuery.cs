using SmartShop.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Queries
{
    public class LoginQuery
    {
        public QueryService SearchAccountUser(string user, string pass)
        {
            var query = new QueryService("sp_GetAccountUser", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@UserName", user),
                new SqlParameter("@Password", pass)
            };
            return query;
        }
    }
}
