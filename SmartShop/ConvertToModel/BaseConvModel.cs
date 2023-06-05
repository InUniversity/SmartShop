using System.Data.SqlClient;

namespace SmartShop.ConvertToModel
{
    public abstract class BaseConvModel
    {
        //product
        protected const string prodTbl = "Products";
        protected const string prodID = "ID";
        protected const string prodCtgID = "CategoryID";
        protected const string prodImgUrl = "ImageUrl";
        protected const string prodName = "ProductName";
        protected const string prodPrice = "Price";
        protected const string prodQty = "RemainQuantity";
        protected const string prodDescription = "ProductDescription";
        //cartItem
        protected const string cartItTbl = "CartItems";
        protected const string cartItID = "ID";
        protected const string cartItUserID = "UserID";
        protected const string cartItProdID = "ProductID";
        protected const string cartItQty = "Quantity";
        //Categories
        protected const string ctgTbl = "Categories";
        protected const string ctgID = "ID";
        protected const string ctgName = "CategoryName";
        //order
        protected const string ordTbl = "Orders";
        protected const string ordID = "ID";
        protected const string orduID = "UserID";
        protected const string ordSttusID = "StatusID";
        protected const string ordDate = "OrderDate";
        // orderitem
        protected const string ordItemTbl = "OrderItems";
        protected const string ordItemID = "ID";
        protected const string ordItemOrdID = "OrderID";
        protected const string ordItemProdID = "ProductID";
        protected const string ordItemQty = "Quantity";
        //user
        protected const string userTbl = "Users";
        protected const string userID = "ID";
        protected const string userfname = "FullName";
        protected const string username = "Username";
        protected const string pass = "PasswordHash";
        protected const string useremail = "Email";
        protected const string userphone = "Phone";
        protected const string userwBalance = "WalletBalance";
        protected const string userAddress = "UsrAddress";
        //userAccount
        protected const string UserAccTbl = "UserAccount";
        protected const string urAcID = "UserID";
        protected const string urAcName = "UserName";
        protected const string urAcPassHash = "Password";
        protected const string urAcEmail = "Email";
        protected const string urAcRole = "Role";

        public abstract object Conv(SqlDataReader reader);
    }
}