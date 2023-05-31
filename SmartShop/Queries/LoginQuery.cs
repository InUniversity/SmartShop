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
        public QueryService Login(string user, string pass, out SqlParameter notificationParameter)
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
    }
}
