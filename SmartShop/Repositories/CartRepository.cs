using SmartShop.Models;
using SmartShop.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartShop.Database;

namespace SmartShop.Repositories
{
    public class CartRepository : BaseRepository
    {
        public CartRepository(DbConnection dbConn) : base(dbConn)
        {

        }

        public bool Add(Cart cart)
        {
            string spCmd = $"sp_AddCart";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@CartID", cart.ID),
                new SqlParameter("@UserID", cart.UserID),
                new SqlParameter("@TotalPrice", cart.TotalPrice),
                new SqlParameter("@UpdateAt", cart.UpdateAt)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Delete(string id)
        {
            string spCmd = $"sp_DeleteCart";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@CartID", id),
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Update(Cart cart)
        {
            string spCmd = $"sp_UpdateCart";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@CartID", cart.ID),
                new SqlParameter("@NewUserID", cart.UserID),
                new SqlParameter("@NewTotalPrice", cart.TotalPrice),
                new SqlParameter("@NewUpdateAt", cart.UpdateAt)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public Cart SearchByID(string id)
        {
            string spCmd = $"sp_Ser_Carts_By_ID";
            SqlParameter[] paras = new[]
            {
                new SqlParameter($"@{cartID}", id),
            };
            return (Cart)dbConn.GetSingleObject(spCmd, paras, Converter);
        }

        private Cart Converter(SqlDataReader reader)
        {
            return new Cart
            {
                ID = (string)reader[cartID],
                UserID = (string)reader[cartUserID],
                TotalPrice = (decimal)reader[cartTtp],
                UpdateAt = (DateTime)reader[cartUda],
            };
        }
    }
}
