using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartShop.Database;
using SmartShop.Models;
using SmartShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            dbConn = new DbConnection();
            myRepo = new UserRepository(dbConn);
        }

        [TestMethod]
        public void Add_Delete_Update_Success()
        {
            var addTarget = new User
            {
                ID = "USR0123",
                FirstName = "Tan",
                LastName = "Le",
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
                FirstName = "An",
                LastName = "Tran",
                Username = "Antran12",
                Pass = "123",
                Email = "antran@gmail.com",
                Phone = "0776506179",
                WalletBalance = (decimal)101230.12,
                RoleID = "ROLE0001"
            };
            bool isUpdateSuccess = myRepo.Update(updateTarget);
            var updateResult = myRepo.SearchByID(addTarget.ID);

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
            Assert.AreEqual(expected.ID, actual.ID);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.Username, actual.Username);
            Assert.AreEqual(expected.Pass, actual.Pass);
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.Phone, actual.Phone);
            Assert.AreEqual(expected.WalletBalance, actual.WalletBalance);
            Assert.AreEqual(expected.RoleID, actual.RoleID);
        }
    }
}
