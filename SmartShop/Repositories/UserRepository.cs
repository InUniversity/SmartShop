using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartShop.Database;
namespace SmartShop.Repositories
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(DbConnection dbConn) : base(dbConn)
        {

        }

        public bool Add(User user)
        {
            string spCmd = $"sp_Add_User";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@id", user.ID),
                new SqlParameter("@fname", user.FirstName),
                new SqlParameter("@lname", user.LastName),
                new SqlParameter("@username", user.Username),
                new SqlParameter("@pass", user.PasswordHash),
                new SqlParameter("@email", user.Email),
                new SqlParameter("@phone", user.Phone),
                new SqlParameter("@wBlc", user.WalletBalance),
                new SqlParameter("@roleid", user.RoleID)

            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Delete(string id)
        {
            string spCmd = $"sp_Delete_User";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@id", id),
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Update(User user)
        {
            string spCmd = $"sp_Update_User";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@id", user.ID),
                new SqlParameter("@fname", user.FirstName),
                new SqlParameter("@lname", user.LastName),
                new SqlParameter("@username", user.Username),
                new SqlParameter("@pass", user.PasswordHash),
                new SqlParameter("@email", user.Email),
                new SqlParameter("@phone", user.Phone),
                new SqlParameter("@wBlc", user.WalletBalance),
                new SqlParameter("@roleid", user.RoleID)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public User SearchByID(string id)
        {
            string spCmd = $"sp_Ser_User_By_ID";
            SqlParameter[] paras = new[]
            {
                new SqlParameter($"@{userID}", id),
            };
            return (User)dbConn.GetSingleObject(spCmd, paras, Converter);
        }

        private User Converter(SqlDataReader reader)
        {
            return new User
            {
                ID = (string)reader[prodID],
                FirstName = (string)reader[userfname],
                LastName = (string)reader[userlname],
                Username = (string)reader[username],
                PasswordHash = (string)reader[pass],
                Email = (string)reader[useremail],
                Phone = (string)reader[userphone],
                WalletBalance = reader.GetDecimal(reader.GetOrdinal(userwBalance)),
                RoleID = (string)reader[userrID],
            };
        }
    }
}
