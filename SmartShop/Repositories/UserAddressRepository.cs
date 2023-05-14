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
    public class UserAddressRepository:BaseRepository
    {
        public UserAddressRepository(DbConnection dbConn) : base(dbConn)
        {

        }

        public bool Add(UserAddress uaddress)
        {
            string spCmd = $"sp_Add_UserAddress";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@id", uaddress.ID),
                new SqlParameter("@userID",uaddress.UserID),
                new SqlParameter("@detail", uaddress.Details)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Delete(string id)
        {
            string spCmd = $"sp_Delete_UserAddress";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@id", id),
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Update(UserAddress uaddress)
        {
            string spCmd = $"sp_Update_UserAddress";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@id", uaddress.ID),
                new SqlParameter("@userID",uaddress.UserID),
                new SqlParameter("@detail", uaddress.Details)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public UserAddress SearchByID(string id)
        {
            string spCmd = $"sp_Ser_UserAddress_By_ID";
            SqlParameter[] paras = new[]
            {
                new SqlParameter($"@{uadresID}", id),
            };
            return (UserAddress)dbConn.GetSingleObject(spCmd, paras, Converter);
        }

        private UserAddress Converter(SqlDataReader reader)
        {
            return new UserAddress
            {
                ID = (string)reader[uadresID],
                UserID = (string)reader[uadresUsID],
                Details = (string)reader[uadDetail],
            };
        }
    }
}
