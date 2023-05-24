using System;
using System.Data;
using System.Data.SqlClient;
using SmartShop.Models;

namespace SmartShop.ConvertToModel
{
    public class ToCategory : BaseConvModel
    {
        public override object Conv(DataRow row)
        {
            Category ctg = null;
            try
            {
                ctg = new Category
                {
                    ID = (string)row[ctgID],
                    Name = (string)row[ctgName],
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return ctg;
        }

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