using System;
using System.Data.SqlClient;
using SmartShop.Models;

namespace SmartShop.ConvertToModel
{
    public class ToCategory : BaseConvModel
    {
        public override object Conv(SqlDataReader reader)
        {
            Category ctg = null;
            try
            {
                ctg = new Category
                {
                    ID = (string)reader[ctgID],
                    Name = (string)reader[ctgName],
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return ctg;
        }
    }
}