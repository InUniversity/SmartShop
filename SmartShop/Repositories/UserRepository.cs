using System.Data.SqlClient;
using SmartShop.Database;
using SmartShop.Models;

namespace SmartShop.Repositories
{
    public class UserRepository :BaseRepository
    {
        public UserRepository(DbConnection dbConn) : base(dbConn)
        {

        }

        public bool Add(User user)
        {
            string spCmd = "dbo.sp_AddUser";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@UserID", user.ID),
                new SqlParameter("@FirstName", user.FirstName),
                new SqlParameter("@LastName", user.LastName),
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
                new SqlParameter("@NewFirstName", user.FirstName),
                new SqlParameter("@NewLastName", user.LastName),
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
            return (User)dbConn.GetSingleObject(spCmd, paras, Converter);
        }

        private User Converter(SqlDataReader reader)
        {
            return new User
            {
                ID = (string)reader[userID],
                FirstName = (string)reader[userfname],
                LastName = (string)reader[userlname],
                Username = (string)reader[username],
                Pass = (string)reader[pass],
                Email = (string)reader[useremail],
                Phone = (string)reader[userphone],
                WalletBalance = reader.GetDecimal(reader.GetOrdinal(userwBalance)),
                RoleID = (string)reader[userrID],
            };
        }
    }
}
