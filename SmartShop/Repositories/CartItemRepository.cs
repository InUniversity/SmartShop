using SmartShop.Models;
using System.Data.SqlClient;
using SmartShop.Database;

namespace SmartShop.Repositories
{
    public class CartItemRepository : BaseRepository
    {
        public CartItemRepository(DbConnection dbConn, DbConverter dbConv) : base(dbConn, dbConv)
        {
        }

        public bool Add(CartItem item)
        {
            string spCmd = $"sp_AddCartItem";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@CartItemID", item.ID),
                new SqlParameter("@UserID",item.UserID),
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
                new SqlParameter("@NewUserID",item.UserID),
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
            return dbConn.GetSingleObject(spCmd, paras, dbConv.ToModel<CartItem>);
        }
    }
}
