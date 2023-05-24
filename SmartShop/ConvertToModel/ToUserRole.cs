using System;
using System.Data.SqlClient;

namespace SmartShop.ConvertToModel
{
    public class ToUserRole : BaseConvModel
    {
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