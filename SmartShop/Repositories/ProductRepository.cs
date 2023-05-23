﻿using SmartShop.Database;
using SmartShop.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SmartShop.Repositories
{
    public class ProductRepository : BaseRepository
    {
        public ProductRepository(DbConnection dbConn) : base(dbConn)
        {
            
        }

        public bool Add(Product prod)
        {
            string spCmd = $"sp_AddProduct";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@ProductID", prod.ID),
                new SqlParameter("@CategoryID", prod.CategoryID),
                new SqlParameter("@ImageUrl", prod.ImgUrl),
                new SqlParameter("@ProductName", prod.Name),
                new SqlParameter("@Price", prod.Price),
                new SqlParameter("@Quantity", prod.Quantity),
                new SqlParameter("@ProductDescription", prod.Desc)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras);
        }

        public bool Delete(string id)
        {
            string spCmd = $"sp_DeleteProduct";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@ProductID", id),
            };
            return dbConn.ExecuteNonQuery(spCmd, paras); 
        }

        public bool Update(Product prod)
        {
            string spCmd = $"sp_UpdateProduct";
            SqlParameter[] paras = new[]
            {
                new SqlParameter("@ProductID", prod.ID),
                new SqlParameter("@NewCategoryID", prod.CategoryID),
                new SqlParameter("@NewImageUrl", prod.ImgUrl),
                new SqlParameter("@NewProductName", prod.Name),
                new SqlParameter("@NewPrice", prod.Price),
                new SqlParameter("@NewQuantity", prod.Quantity),
                new SqlParameter("@NewProductDescription", prod.Desc)
            };
            return dbConn.ExecuteNonQuery(spCmd, paras); 
        }

        public Product SearchByID(string id)
        {
            string spCmd = $"sp_Ser_Prod_By_ID";
            SqlParameter[] paras = new[]
            {
                new SqlParameter($"@ID", id),
            };
            return (Product)dbConn.GetSingleObject(spCmd, paras, Converter); 
        }
        
        public List<Product> GetAll()
        {
            string sqlStr = $"SELECT * FROM {prodTbl}";
            return dbConn.GetEnumerable(sqlStr, Converter).ToList();
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
                Desc = (string)reader[prodDescription],
            };
        }
    }
}
