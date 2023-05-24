using System;
using System.Data;
using System.Data.SqlClient;
using SmartShop.Models;

namespace SmartShop.ConvertToModel
{
    public class ToOrder : BaseConvModel
    {
        public override object Conv(DataRow row)
        {
            Order ord = null;
            try
            {
                ord = new Order
                {
                    ID = (string)row[ordID],
                    UserID = (string)row[orduID],
                    StatusID = (string)row[ordSttusID],
                    Date = (DateTime)row[ordDate]
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return ord;
        }

        public override object Conv(SqlDataReader reader)
        {
            Order ord = null;
            try
            {
                ord = new Order
                {
                    ID = (string)reader[ordID],
                    UserID = (string)reader[orduID],
                    StatusID = (string)reader[ordSttusID],
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