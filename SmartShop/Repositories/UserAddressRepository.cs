﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartShop.Database;
using SmartShop.Models;

namespace SmartShop.Repositories
{
    public class UserAddressRepository :BaseRepository
    {
        public UserAddressRepository(DbConnection dbConn) : base(dbConn)
        {

        }

        public bool Add(UserAddress uaddress)
        {
            string spCmd = $"sp_AddUserAddress";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@AddressID", uaddress.ID),
                new SqlParameter("@UserID",uaddress.UserID),
                new SqlParameter("@AddressDetails", uaddress.Details)
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

        public bool Update(UserAddress uaddress)
        {
            string spCmd = $"sp_UpdateUserAddress";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@AddressID", uaddress.ID),
                new SqlParameter("@NewUserID",uaddress.UserID),
                new SqlParameter("@NewAddressDetails", uaddress.Details)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public UserAddress SearchByID(string id)
        {
            string spCmd = $"sp_Ser_UserA_By_ID";
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
