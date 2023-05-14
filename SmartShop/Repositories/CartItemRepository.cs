using SmartShop.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartShop.Database;
using System.Windows.Input;
using SmartShop.Views.UserControls;

namespace SmartShop.Repositories
{
    public class CartItemRepository : BaseRepository
    {
        public CartItemRepository(DbConnection dbConn) : base(dbConn)
        {

        }

        public bool Add(CartItem cartit)
        {
            string spCmd = $"sp_Add_CartItem";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@id", cartit.ID),
                new SqlParameter("@cartid",cartit.CartID),
                new SqlParameter("@proID", cartit.ProductID),
                new SqlParameter("@quatity", cartit.Quantity)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Delete(string id)
        {
            string spCmd = $"sp_Delete_CartItem";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@id", id),
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Update(CartItem cartit)
        {
            string spCmd = $"sp_Update_Product";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@id", cartit.ID),
                new SqlParameter("@cartid",cartit.CartID),
                new SqlParameter("@proID", cartit.ProductID),
                new SqlParameter("@quatity", cartit.Quantity)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public CartItem SearchByID(string id)
        {
            string spCmd = $"sp_Ser_CartItem_By_ID";
            SqlParameter[] paras = new[]
            {
                new SqlParameter($"@{cartitID}", id),
            };
            return (CartItem)dbConn.GetSingleObject(spCmd, paras, Converter);
        }

        private CartItem Converter(SqlDataReader reader)
        {
            return new CartItem
            {
                ID = (string)reader[cartitID],
                CartID = (string)reader[cartit_cartID],
                ProductID = (string)reader[cartit_prodID],
                Quantity = (int)reader[cartitQty],
            };
        }
    }
}
