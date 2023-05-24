using System.Data;
using System.Data.SqlClient;
using SmartShop.Services;

namespace SmartShop.Queries
{
    public class UserRoleQuery
    {
        public QueryService Add(UserRole urole)
        {
            var query = new QueryService("sp_AddUserRole", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@RoleID", urole.ID),
                new SqlParameter("@RoleName", urole.Name)
            };
            return query;
            
        }

        public QueryService Delete(string id)
        {
            var query = new QueryService("sp_DeleteUserRole", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@RoleID", id),
            };
            return query;
        }

        public QueryService Update(UserRole urole)
        {
            var query = new QueryService("sp_UpdateUserRole", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@RoleID", urole.ID),
                new SqlParameter("@NewRoleName", urole.Name)
            };
            return query;
        }

        public QueryService SearchByID(string id)
        {
            var query = new QueryService("sp_Ser_UserR_By_ID", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@ID", id),
            };
            return query;
        }
    }
}