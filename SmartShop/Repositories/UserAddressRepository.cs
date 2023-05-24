using System;
using System.Collections.Generic;
using SmartShop.Database;
using SmartShop.Models;
using SmartShop.Queries;

namespace SmartShop.Repositories
{
    public class UserAddressRepository : BaseRepository
    {
        private readonly UserAddressQuery query;
        
        public UserAddressRepository(DbConnection dbConn, DbConverter dbConv, UserAddressQuery query) : base(dbConn, dbConv)
        {
            this.query = query;
        }

        public bool Add(UserAddress address)
        {
            var qry = query.Add(address);
            return dbConn.ExecuteNonQuery(qry);
        }

        public bool Delete(string id)
        {
            var qry = query.Delete(id);
            return dbConn.ExecuteNonQuery(qry);
        }

        public bool Update(UserAddress address)
        {
            var qry = query.Update(address);
            return dbConn.ExecuteNonQuery(qry);
        }

        public UserAddress SearchByID(string id)
        {
            var qry = query.SearchByID(id);
            using var reader = dbConn.ExecuteReader(qry);
            return dbConv.ToSingleObject<UserAddress>(reader);
        }

        public List<UserAddress> SearchByUserID(string userID)
        {
            throw new NotImplementedException();
        }
    }
}
