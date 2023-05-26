using System;
using System.Data.SqlClient;
using SmartShop.Models;

namespace SmartShop.ConvertToModel
{
    public class ToCartItemView : ToCartItem
    {
        public override object Conv(SqlDataReader reader)
        {
            var item = (CartItem)base.Conv(reader);
            CartItemView itemView = null;
            try
            {
                itemView = new CartItemView
                {
                    ID = item.ID,
                    UserID = item.UserID,
                    ProdID = item.ProdID,
                    Quantity = item.Quantity,
                    ImgUrl = (string)reader[prodImgUrl],
                    Name = (string)reader[prodName],
                    Price = reader.GetDecimal(reader.GetOrdinal(prodPrice)),
                    RemainQuantity = (int)reader[prodQty],
                    Desc = (string)reader[prodDescription],
                    CategoryName = (string)reader[ctgName]
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return itemView;
        }
    }
}