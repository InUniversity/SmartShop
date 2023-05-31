using SmartShop.Models;

namespace SmartShop.Database
{
    public class CurrentDb
    {
        public const string serverName = "(localdb)\\mssqllocaldb";
        public const string dbName = "SmartShop";
        
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
    }
}