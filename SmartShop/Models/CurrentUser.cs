namespace SmartShop.Models
{
    public class CurrentUser
    {
        private static CurrentUser ins;
        private User user = new User();

        public static CurrentUser Ins
        {
            get
            {
                if (ins == null)
                {
                    ins = new CurrentUser();
                }
                return ins;
            }
        }

        private CurrentUser()
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