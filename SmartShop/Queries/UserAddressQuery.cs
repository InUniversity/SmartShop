using System;
using System.Data;
using System.Data.SqlClient;
using SmartShop.Models;
using SmartShop.Services;

namespace SmartShop.Queries
{
    public class UserAddressQuery
    {
        public QueryService Add(UserAddress address)
        {
            var query = new QueryService("sp_AddUserAddress", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@AddressID", address.ID),
                new SqlParameter("@UserID", address.UserID),
                new SqlParameter("@AddressDetails", address.Details)
            };
            return query;
        }

        public QueryService Delete(string id)
        {
            var query = new QueryService("sp_DeleteUserAddress", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@AddressID", id)
            };
            return query;
        }

        public QueryService Update(UserAddress address)
        {
            var query = new QueryService("sp_UpdateUserAddress", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@AddressID", address.ID),
                new SqlParameter("@NewUserID",address.UserID),
                new SqlParameter("@NewAddressDetails", address.Details)
            };
            return query;
        }

        public QueryService SearchByID(string id)
        {
            var query = new QueryService("sp_Ser_UserA_By_ID", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@ID", id)
            };
            return query;
        }

        public QueryService SearchByUserID(string userID)
        {
            throw new NotImplementedException();
        } 
    }
}