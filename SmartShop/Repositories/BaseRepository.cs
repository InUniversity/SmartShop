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
        //cartItem
        protected const string cartItTbl = "CartItems";
        protected const string cartItID = "ID";
        protected const string cartItUserID = "UserID";
        protected const string cartItProdID = "ProductID";
        protected const string cartItQty = "Quantity";
        //order
        protected const string ordTbl = "Orders";
        protected const string ordID = "ID";
        protected const string orduID = "UserID";
        protected const string ordSttusID = "StatusID";
        protected const string ordDate = "OrderDate";
        //orderStatus
        protected const string ordstTbl = "OrderStatus";
        protected const string ordstID = "ID";
        protected const string ordstname = "StatusName";
        //user
        protected const string userTbl = "Users";
        protected const string userID = "ID";
        protected const string userfname = "FirstName";
        protected const string userlname = "LastName";
        protected const string username = "Username";
        protected const string pass = "PasswordHash";
        protected const string useremail = "Email";
        protected const string userphone = "Phone";
        protected const string userwBalance = "WalletBalance";
        protected const string userrID = "RoleID";
        //userrole
        protected const string uroleTbl = "UserRole";
        protected const string uroleID = "ID";
        protected const string uroleName = "RoleName";
        //useraddress
        protected const string uadresTbl = "UserAddress";
        protected const string uadresID = "ID";
        protected const string uadresUsID = "UserID";
        protected const string uadDetail = "AddressDetails";

        protected DbConnection dbConn;

        protected BaseRepository(DbConnection dbConn)
        {
            this.dbConn = dbConn;
        }
    }
}
