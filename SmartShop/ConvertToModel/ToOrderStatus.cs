using System;
using System.Data.SqlClient;
using SmartShop.Models;

namespace SmartShop.ConvertToModel
{
    public class ToOrderStatus : BaseConvModel
    {
        public override object Conv(SqlDataReader reader)
        {
            OrderStatus status = null;
            try
            {
                status = new OrderStatus
                {
                    ID = (string)reader[ordSttusID],
                    Name = (string)reader[ordStaName]
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return status;
        }
    }
}