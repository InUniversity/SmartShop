using SmartShop.Models;
using System.Data.SqlClient;
using System;

namespace SmartShop.ConvertToModel
{
    public class ToOrderItemView : ToOrderItem
    {
        public override object Conv(SqlDataReader reader)
        {
            var item = (OrderItem)base.Conv(reader);
            OrderItemView itemView = null;
            try
            {
                itemView = new OrderItemView
                {
                    ID = item.ID,
                    OrderID = item.OrderID,
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
