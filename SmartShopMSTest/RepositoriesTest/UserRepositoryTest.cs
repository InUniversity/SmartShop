using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartShop.Database;
using SmartShop.Models;
using SmartShop.Repositories;
using SmartShop.ConvertToModel;
using SmartShop.Queries;

namespace SmartShopMSTest.RepositoriesTest
{
    [TestClass]
    public class UserRepositoryTest
    {
        private DbConnection dbConn;
        private UserRepository myRepo;

        [TestInitialize]
        public void SetUp()
        {
            var conn = new SqlConnection("");
            var dbConn = new DbConnection(conn);
            var convModelFactory = new ConvModelFactory();
            var dbConv = new DbConverter(convModelFactory);
            var userQuery = new UserQuery();
            myRepo = new UserRepository(dbConn, dbConv, userQuery);
        }

        [TestMethod]
        public void Add_Delete_Update_Success()
        {
            var addTarget = new User
            {
                ID = "USR0123",
                FullName = "Tan Le",
                Username = "Letan123",
                Pass = "1234567",
                Email = "letan@gmail.com",
                Phone = "0776506179",
                WalletBalance = (decimal)101230.12,
                RoleID = "ROLE0001"
            };
            bool isAddSuccess = myRepo.Add(addTarget);
            var addResult = myRepo.SearchByID(addTarget.ID);

            // Do not modify the ID
            var updateTarget = new User
            {
                ID = addTarget.ID,
                FullName = "Tran An",
                Username = "Antran12",
                Pass = "123",
                Email = "antran@gmail.com",
                Phone = "0776506179",
                WalletBalance = (decimal)101230.12,
                RoleID = "ROLE0001"
            };
            bool isUpdateSuccess = myRepo.Update(updateTarget);
            var updateResult = myRepo.SearchByID(addTarget.ID);

            if (isAddSuccess)
                myRepo.Delete(addTarget.ID);
            var deleteResult = myRepo.SearchByID(addTarget.ID);

            // test add
            Assert.IsTrue(isAddSuccess);
            AssertObj(addTarget, addResult);

            // test update
            Assert.IsTrue(isUpdateSuccess);
            AssertObj(updateTarget, updateResult);

            // test delete
            Assert.IsNull(deleteResult);
        }

        private void AssertObj(User expected, User actual)
        {
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.ID, actual.ID);
            Assert.AreEqual(expected.FullName, actual.FullName);
            Assert.AreEqual(expected.Username, actual.Username);
            Assert.AreEqual(expected.Pass, actual.Pass);
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.Phone, actual.Phone);
            Assert.AreEqual(expected.WalletBalance, actual.WalletBalance);
            Assert.AreEqual(expected.RoleID, actual.RoleID);
        }
    }
}
