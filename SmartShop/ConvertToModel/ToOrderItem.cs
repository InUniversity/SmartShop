using System;
using System.Data;
using System.Data.SqlClient;

namespace SmartShop.ConvertToModel
{
    public class ToOrderItem : BaseConvModel
    {
        public override object Conv(DataRow row)
        {
            OrderItem ordItem = null;
            try
            {
                ordItem = new OrderItem
                {
                    ID = (string)row[ordItemID],
                    OrderID = (string)row[ordItemOrdID],
                    ProdID = (string)row[ordItemProdID],
                    Quantity = (int)row[ordItemQty]
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return ordItem;
        }

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