using SmartShop.Database;
using SmartShop.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SmartShop.Repositories
{
    public class ProductRepository : BaseRepository
    {
        public ProductRepository(DbConnection dbConn) : base(dbConn)
        {
            
        }

        public bool Add(Product prod)
        {
            string spCmd = $"sp_Add_Product";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@id", prod.ID),
                new SqlParameter("@ctgID", prod.CategoryID),
                new SqlParameter("@imgUrl", prod.ImgUrl),
                new SqlParameter("@name", prod.Name),
                new SqlParameter("@price", prod.Price),
                new SqlParameter("@qty", prod.Quantity),
                new SqlParameter("@description", prod.Description)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Delete(string id)
        {
            string spCmd = $"sp_Delete_Product";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@id", id),
            };
            return dbConn.ExecuteNonQuery(spCmd, paras); 
        }

        public bool Update(Product prod)
        {
            string spCmd = $"sp_Update_Product";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@id", prod.ID),
                new SqlParameter("@ctgID", prod.CategoryID),
                new SqlParameter("@imgUrl", prod.ImgUrl),
                new SqlParameter("@name", prod.Name),
                new SqlParameter("@price", prod.Price),
                new SqlParameter("@qty", prod.Quantity),
                new SqlParameter("@description", prod.Description)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras); 
        }

        public Product SearchByID(string id)
        {
            string spCmd = $"sp_Ser_Prod_By_ID";
            SqlParameter[] paras = new[]
            {
                new SqlParameter($"@{prodID}", id),
            };
            return (Product)dbConn.GetSingleObject(spCmd, paras, Converter); 
        }

        private Product Converter(SqlDataReader reader)
        {
            return new Product
            {
                ID = (string)reader[prodID],
                CategoryID = (string)reader[prodCtgID],
                ImgUrl = (string)reader[prodImgUrl],
                Name = (string)reader[prodName],
                Price = reader.GetDecimal(reader.GetOrdinal(prodPrice)),
                Quantity = (int)reader[prodQty],
                Description = (string)reader[prodDescription],
            };
        }
    }
}
