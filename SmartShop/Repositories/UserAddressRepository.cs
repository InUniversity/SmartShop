using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SmartShop.Database;
using SmartShop.Models;

namespace SmartShop.Repositories
{
    public class UserAddressRepository : BaseRepository
    {
        public UserAddressRepository(DbConnection dbConn, DbConverter dbConv) : base(dbConn, dbConv)
        {
        }

        public bool Add(UserAddress address)
        {
            string spCmd = $"sp_AddUserAddress";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@AddressID", address.ID),
                new SqlParameter("@UserID", address.UserID),
                new SqlParameter("@AddressDetails", address.Details)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Delete(string id)
        {
            string spCmd = $"sp_DeleteUserAddress";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@AddressID", id),
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Update(UserAddress address)
        {
            string spCmd = $"sp_UpdateUserAddress";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@AddressID", address.ID),
                new SqlParameter("@NewUserID",address.UserID),
                new SqlParameter("@NewAddressDetails", address.Details)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public UserAddress SearchByID(string id)
        {
            string spCmd = $"sp_Ser_UserA_By_ID";
            SqlParameter[] paras = new[]
            {
                new SqlParameter($"@ID", id),
            };
            return dbConn.GetSingleObject(spCmd, paras, dbConv.ToModel<UserAddress>);
        }

        public List<UserAddress> SearchByUserID(string userID)
        {
            throw new NotImplementedException();
        }
    }
}
