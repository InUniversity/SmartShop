using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartShop.Database;
using MaterialDesignThemes.Wpf;

namespace SmartShop.Repositories
{
    public class CartRepository: BaseRepository
    {
        public CartRepository(DbConnection dbConn) : base(dbConn)
        {

        }

        public bool Add(Cart cart)
        {
            string spCmd = $"sp_Add_Cart";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@id", cart.ID),
                new SqlParameter("@uID", cart.UserID),
                new SqlParameter("@totalPrice", cart.TotalPrice),
                new SqlParameter("@updateAt", cart.UpdateAt)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Delete(string id)
        {
            string spCmd = $"sp_Delete_Cart";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@id", id),
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Update(Cart cart)
        {
            string spCmd = $"sp_Update_Cart";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@id", cart.ID),
                new SqlParameter("@uID", cart.UserID),
                new SqlParameter("@totalPrice", cart.TotalPrice),
                new SqlParameter("@updateAt", cart.UpdateAt)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public Cart SearchByID(string id)
        {
            string spCmd = $"sp_Ser_Cart_By_ID";
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
