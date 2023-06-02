using SmartShop.Models;

namespace SmartShop.Database
{
    public class CurrentDb
    {
        private static CurrentDb ins;
        private User user = new User();

        public static CurrentDb Ins
        {
            get
            {
                if (ins == null)
                {
                    ins = new CurrentDb();
                }
                return ins;
            }
        }

        private CurrentDb()
        {
            user = new User();
        }

        public User Usr
        {
            get => user;
            set => user = value;
        }
        
        public string ServerName = "(localdb)\\mssqllocaldb";
        public string DbName = "SmartShop";

        public string GetConnStr(string username, string pass)
        {
            return $"Data Source={ServerName};Initial Catalog={DbName};Persist Security Info=True;User ID={username};Password={pass}";
        }
    }
}