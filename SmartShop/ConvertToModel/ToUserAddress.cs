using System;
using System.Data;
using System.Data.SqlClient;
using SmartShop.Models;

namespace SmartShop.ConvertToModel
{
    public class ToUserAddress : BaseConvModel
    {
        public override object Conv(DataRow row)
        {
            UserAddress usrAddress = null;
            try
            {
                usrAddress = new UserAddress
                {
                    ID = (string)row[uadresID],
                    UserID = (string)row[uadresUsID],
                    Details = (string)row[uadDetail]
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return usrAddress;
        }

        public override object Conv(SqlDataReader reader)
        {
            UserAddress usrAddress = null;
            try
            {
                usrAddress = new UserAddress
                {
                    ID = (string)reader[uadresID],
                    UserID = (string)reader[uadresUsID],
                    Details = (string)reader[uadDetail]
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return usrAddress;
        }
    }
}