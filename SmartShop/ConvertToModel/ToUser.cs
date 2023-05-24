using System;
using System.Data;
using System.Data.SqlClient;
using SmartShop.Models;

namespace SmartShop.ConvertToModel
{
    public class ToUser : BaseConvModel
    {
        public override object Conv(DataRow row)
        {
            User user = null;
            try
            {
                user = new User
                {
                    ID = (string)row[userID],
                    FullName = (string)row[userfname],
                    Username = (string)row[username],
                    Pass = (string)row[pass],
                    Email = (string)row[useremail],
                    Phone = (string)row[userphone],
                    WalletBalance = (decimal)row[userwBalance],
                    RoleID = (string)row[userrID]
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return user;
        }

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