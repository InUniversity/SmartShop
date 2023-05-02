using SmartShop.Database;

namespace SmartShop.Repositories
{
    public abstract class BaseRepository
    {
        protected const string prodTbl = "Products";
        protected const string prodID = "ID";
        protected const string prodCtgID = "CategoryID";
        protected const string prodImgUrl = "ImageUrl";
        protected const string prodName = "ProductName";
        protected const string prodPrice = "Price";
        protected const string prodQty = "Quantity";
        protected const string prodDescription = "ProductDescription";

        protected DbConnection dbConn;

        protected BaseRepository(DbConnection dbConn)
        {
            this.dbConn = dbConn;
        }
    }
}
