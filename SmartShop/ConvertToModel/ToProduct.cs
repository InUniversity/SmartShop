using System;
using System.Data;
using System.Data.SqlClient;
using SmartShop.Models;

namespace SmartShop.ConvertToModel
{
    public class ToProduct : BaseConvModel
    {
        public override object Conv(DataRow row)
        {
            Product prod = null;
            try
            {
                prod = new Product
                {
                    ID = (string)row[prodID],
                    CategoryID = (string)row[prodCtgID],
                    ImgUrl = (string)row[prodImgUrl],
                    Name = (string)row[prodName],
                    Price = (decimal)row[prodPrice],
                    Quantity = (int)row[prodQty],
                    Desc = (string)row[prodDescription],
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return prod;
        }

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