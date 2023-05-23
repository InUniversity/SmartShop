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

        public bool Add(CartItem cartit)
        {
            string spCmd = $"sp_AddCartItem";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@CartItemID", cartit.ID),
                new SqlParameter("@CartID",cartit.CartID),
                new SqlParameter("@ProductID", cartit.ProdID),
                new SqlParameter("@Quantity", cartit.Quantity)
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

        public bool Update(CartItem cartit)
        {
            string spCmd = $"sp_UpdateCartItem";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@CartItemID", cartit.ID),
                new SqlParameter("@NewCartID",cartit.CartID),
                new SqlParameter("@NewProductID", cartit.ProdID),
                new SqlParameter("@NewQuantity", cartit.Quantity)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public CartItem SearchByID(string id)
        {
            string spCmd = $"sp_Ser_CartItems_By_ID";
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
                ProdID = (string)reader[cartit_prodID],
                Quantity = (int)reader[cartitQty],
            };
        }
    }
}
