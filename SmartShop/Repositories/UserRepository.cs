using System.Data.SqlClient;
using SmartShop.Database;
using SmartShop.Models;

namespace SmartShop.Repositories
{
    public class UserRepository :BaseRepository
    {
        public UserRepository(DbConnection dbConn, DbConverter dbConv) : base(dbConn, dbConv)
        {
        }

        public bool Add(User user)
        {
            string spCmd = "dbo.sp_AddUser";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@UserID", user.ID),
                new SqlParameter("@FullName", user.FullName),
                new SqlParameter("@Username", user.Username),
                new SqlParameter("@PasswordHash", user.Pass),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@Phone", user.Phone),
                new SqlParameter("@WalletBalance", user.WalletBalance),
                new SqlParameter("@RoleID", user.RoleID)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Delete(string id)
        {
            string spCmd = "dbo.sp_DeleteUser";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@UserID", id),
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Update(User user)
        {
            string spCmd = "dbo.sp_UpdateUser";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@UserID", user.ID),
                new SqlParameter("@NewFullName", user.FullName),
                new SqlParameter("@NewUsername", user.Username),
                new SqlParameter("@NewPasswordHash", user.Pass),
                new SqlParameter("@NewEmail", user.Email),
                new SqlParameter("@NewPhone", user.Phone),
                new SqlParameter("@NewWalletBalance", user.WalletBalance),
                new SqlParameter("@NewRoleID", user.RoleID)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public User SearchByID(string id)
        {
            string spCmd = "sp_Ser_User_By_ID";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@ID", id)
            };
            return dbConn.GetSingleObject(spCmd, paras, dbConv.ToModel<User>);
        }
    }
}
