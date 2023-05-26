using System;
using System.Data.SqlClient;
using SmartShop.Models;

namespace SmartShop.ConvertToModel
{
    public class ToProductView : ToProduct
    {
        public override object Conv(SqlDataReader reader)
        {
            var prod = (Product)base.Conv(reader);
            ProductView prodView = null;
            try
            {
                prodView = new ProductView
                {
                    ID = prod.ID,
                    CategoryID = prod.CategoryID,
                    ImgUrl = prod.ImgUrl,
                    Name = prod.Name,
                    Price = prod.Price,
                    RemainQuantity = prod.RemainQuantity,
                    Desc = prod.Desc, 
                    CategoryName = (string)reader[ctgName]
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return prodView;
        }
    }
}