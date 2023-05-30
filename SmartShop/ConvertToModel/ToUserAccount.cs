using SmartShop.Models;
using SmartShop.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.ConvertToModel
{
    public class ToUserAccount : BaseConvModel
    {
        public override object Conv(SqlDataReader reader)
        {
            UserAccount cartItem = null;
            try
            {
                cartItem = new UserAccount
                {
                    ID = (int)reader[urAcID],
                    UserName = (string)reader[urAcName],
                    PassWord = (string)reader[urAcPassHash],
                    Email = (string)reader[urAcEmail],
                    Role = (string)reader[urAcRole],
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return cartItem;
        }
    }
}
