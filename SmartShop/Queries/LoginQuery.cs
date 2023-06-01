using SmartShop.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartShop.Models;

namespace SmartShop.Queries
{
    public class LoginQuery
    {
        public QueryService ffLogin(string user, string pass, out SqlParameter notificationParameter)
        {
            notificationParameter = new SqlParameter("@Notification", SqlDbType.NVarChar, 1000);
            notificationParameter.Direction = ParameterDirection.Output;
            var query = new QueryService("sp_Login", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@UserName", user),
                new SqlParameter("@Password", pass),
                notificationParameter
            };
            return query;
        }

        public QueryService Login(string username, string pass)
        {
            var query = new QueryService($"SELECT * FROM dbo.fn_LoginValid('{username}', '{pass}')", CommandType.Text);
            return query;
        }

        public QueryService CheckLogin(string username, string pass)
        {
            var query = new QueryService($"SELECT dbo.fn_CheckLogin('{username}', '{pass}')", CommandType.Text);
            return query;
        }
    }
}
