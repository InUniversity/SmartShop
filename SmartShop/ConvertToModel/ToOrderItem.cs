using System;
using System.Data.SqlClient;

namespace SmartShop.ConvertToModel
{
    public class ToOrderItem : BaseConvModel
    {
        public override object Conv(SqlDataReader reader)
        {
            OrderItem ordItem = null;
            try
            {
                ordItem = new OrderItem
                {
                    ID = (string)reader[ordItemID],
                    OrderID = (string)reader[ordItemOrdID],
                    ProdID = (string)reader[ordItemProdID],
                    Quantity = (int)reader[ordItemQty]
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return ordItem;
        }
    }
}