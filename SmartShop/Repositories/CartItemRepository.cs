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
    public class CartItemRepository : BaseRepository
    {
        public CartItemRepository(DbConnection dbConn) : base(dbConn)
        {

        }

        public bool Add(CartItem item)
        {
            string spCmd = $"sp_AddCartItem";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@CartItemID", item.ID),
                new SqlParameter("@UserID",item.CartID),
                new SqlParameter("@ProductID", item.ProdID),
                new SqlParameter("@Quantity", item.Quantity)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Delete(string id)
        {
            string spCmd = $"sp_DeleteCartItem";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@CartItemID", id),
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Update(CartItem item)
        {
            string spCmd = $"sp_UpdateCartItem";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@CartItemID", item.ID),
                new SqlParameter("@NewUserID",item.CartID),
                new SqlParameter("@NewProductID", item.ProdID),
                new SqlParameter("@NewQuantity", item.Quantity)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public CartItem SearchByID(string id)
        {
            string spCmd = $"sp_Ser_CartItems_By_ID";
            SqlParameter[] paras = new[]
            {
                new SqlParameter($"@ID", id),
            };
            return (CartItem)dbConn.GetSingleObject(spCmd, paras, Converter);
        }

        private CartItem Converter(SqlDataReader reader)
        {
            return new CartItem
            {
                ID = (string)reader[cartItID],
                CartID = (string)reader[cartItUserID],
                ProdID = (string)reader[cartItProdID],
                Quantity = (int)reader[cartItQty]
            };
        }
    }
}
