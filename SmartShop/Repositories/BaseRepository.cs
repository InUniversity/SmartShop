using SmartShop.Database;

namespace SmartShop.Repositories
{
    public abstract class BaseRepository
    {
        protected DbConnection dbConn;
        protected DbConverter dbConv;

        protected BaseRepository(DbConnection dbConn, DbConverter dbConv)
        {
            this.dbConn = dbConn;
            this.dbConv = dbConv;
        }
    }
}
