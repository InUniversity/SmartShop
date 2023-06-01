using System.Data;
using System.Data.SqlClient;
using SmartShop.Models;
using SmartShop.Services;

namespace SmartShop.Queries
{
    public class UserQuery
    {
       public QueryService Add(User user)
        {
            var query = new QueryService("dbo.sp_AddUser", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@UserID", user.ID),
                new SqlParameter("@FullName", user.FullName),
                new SqlParameter("@Username", user.Username),
                new SqlParameter("@PasswordHash", user.Pass),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@Phone", user.Phone),
                new SqlParameter("@WalletBalance", user.WalletBalance)
            };
            return query;
        }

        public QueryService Delete(string id)
        {
            var query = new QueryService("dbo.sp_DeleteUser", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@UserID", id),
            };
            return query;
        }

        public QueryService Update(User user)
        {
            var query = new QueryService("dbo.sp_UpdateUser", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@UserID", user.ID),
                new SqlParameter("@NewFullName", user.FullName),
                new SqlParameter("@NewUsername", user.Username),
                new SqlParameter("@NewPasswordHash", user.Pass),
                new SqlParameter("@NewEmail", user.Email),
                new SqlParameter("@NewPhone", user.Phone),
                new SqlParameter("@NewWalletBalance", user.WalletBalance)
            };
            return query;
        }

        public QueryService SearchByID(string id)
        {
            var query = new QueryService("sp_Ser_User_By_ID", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@ID", id)
            };
            return query;
        } 
    }
}