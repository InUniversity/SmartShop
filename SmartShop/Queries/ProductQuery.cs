using System.Data;
using System.Data.SqlClient;
using SmartShop.Models;
using SmartShop.Services;

namespace SmartShop.Queries
{
    public class ProductQuery
    {
        public QueryService Add(Product prod)
        {
            var query = new QueryService("sp_AddProduct", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@ProductID", prod.ID),
                new SqlParameter("@CategoryID", prod.CategoryID),
                new SqlParameter("@ImageUrl", prod.ImgUrl),
                new SqlParameter("@ProductName", prod.Name),
                new SqlParameter("@Price", prod.Price),
                new SqlParameter("@Quantity", prod.RemainQuantity),
                new SqlParameter("@ProductDescription", prod.Desc)
            };
            return query;
        }

        public QueryService Delete(string id)
        {
            var query = new QueryService("sp_DeleteProduct", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@ProductID", id),
            };
            return query;
        }

        public QueryService Update(Product prod)
        {
            var query = new QueryService("sp_UpdateProduct", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@ProductID", prod.ID),
                new SqlParameter("@NewCategoryID", prod.CategoryID),
                new SqlParameter("@NewImageUrl", prod.ImgUrl),
                new SqlParameter("@NewProductName", prod.Name),
                new SqlParameter("@NewPrice", prod.Price),
                new SqlParameter("@NewQuantity", prod.RemainQuantity),
                new SqlParameter("@NewProductDescription", prod.Desc)
            };
            return query;
        }

        public QueryService SearchByID(string id)
        {
            var query = new QueryService("sp_Ser_Prod_By_ID", CommandType.StoredProcedure);
            query.Paras = new[]
            {
                new SqlParameter("@ID", id)
            };
            return query;
        }
        
        public QueryService GetAll()
        {
            var query = new QueryService("SELECT * FROM dbo.vw_Products", CommandType.Text);
            return query;
        }

        public QueryService SearchByName(string prodName)
        {
            throw new System.NotImplementedException();
        }
    }
}