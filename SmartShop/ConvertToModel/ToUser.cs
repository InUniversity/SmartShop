using System;
using System.Data.SqlClient;
using SmartShop.Models;

namespace SmartShop.ConvertToModel
{
    public class ToUser : BaseConvModel
    {
        public override object Conv(SqlDataReader reader)
        {
            User user = null;
            try
            {
                user = new User
                {
                    ID = (string)reader[userID],
                    FullName = (string)reader[userfname],
                    Username = (string)reader[username],
                    Pass = (string)reader[pass],
                    Email = (string)reader[useremail],
                    Phone = (string)reader[userphone],
                    WalletBalance = reader.GetDecimal(reader.GetOrdinal(userwBalance)),
                    RoleID = (string)reader[userrID]
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return user;
        }
    }
}