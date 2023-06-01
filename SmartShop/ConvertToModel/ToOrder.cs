using System;
using System.Data.SqlClient;
using SmartShop.Models;

namespace SmartShop.ConvertToModel
{
    public class ToOrder : BaseConvModel
    {
        public override object Conv(SqlDataReader reader)
        {
            Order ord = null;
            try
            {
                ord = new Order
                {
                    ID = (string)reader[ordID],
                    UserID = (string)reader[orduID],
                    Date = (DateTime)reader[ordDate]
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return ord;
        }
    }
}