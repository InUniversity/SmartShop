using System;
using System.Data;
using System.Data.SqlClient;
using SmartShop.Models;

namespace SmartShop.ConvertToModel
{
    public class ToCartItem : BaseConvModel
    {
        public override object Conv(DataRow row)
        {
            CartItem cartItem = null;
            try
            {
                cartItem = new CartItem
                {
                    ID = (string)row[cartItID],
                    UserID = (string)row[cartItUserID],
                    ProdID = (string)row[cartItProdID],
                    Quantity = (int)row[cartItQty]
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return cartItem;
        }

        public override object Conv(SqlDataReader reader)
        {
            CartItem cartItem = null;
            try
            {
                cartItem = new CartItem
                {
                    ID = (string)reader[cartItID],
                    UserID = (string)reader[cartItUserID],
                    ProdID = (string)reader[cartItProdID],
                    Quantity = (int)reader[cartItQty]
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return cartItem;
        }
    }
}