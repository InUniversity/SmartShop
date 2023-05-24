using System;
using System.Data;
using System.Data.SqlClient;

namespace SmartShop.ConvertToModel
{
    public class ToUserRole : BaseConvModel
    {
        public override object Conv(DataRow row)
        {
            UserRole role = null;
            try
            {
                role = new UserRole
                {
                    ID = (string)row[uroleID],
                    Name = (string)row[uroleName],
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return role;
        }

        public override object Conv(SqlDataReader reader)
        {
            UserRole role = null;
            try
            {
                role = new UserRole
                {
                    ID = (string)reader[uroleID],
                    Name = (string)reader[uroleName],
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return role;
        }
    }
}