using System;
using System.Data.SqlClient;
using SmartShop.Models;

namespace SmartShop.ConvertToModel
{
    public class ToProduct : BaseConvModel
    {
        public override object Conv(SqlDataReader reader)
        {
            Product prod = null;
            try
            {
                prod = new Product
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
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return prod;
        }
    }
}