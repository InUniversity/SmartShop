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
    public class ToUserView : ToUser
    {
        public override object Conv(SqlDataReader reader)
        {
            var usr = (User)base.Conv(reader);
            UserView usrView = null;
            try
            {
                usrView = new UserView
                {
                    ID = usr.ID,
                    FullName = usr.FullName,
                    Username = usr.Username,
                    Pass = usr.Pass,
                    Email = usr.Email,
                    Phone = usr.Phone,
                    WalletBalance = usr.WalletBalance,
                    RoleID = usr.RoleID,
                    RoleName = (string)reader[uroleName]
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return usrView;
        }
    }
}
