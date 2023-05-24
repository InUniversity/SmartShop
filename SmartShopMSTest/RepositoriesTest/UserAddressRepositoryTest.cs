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
    public class UserAddressRepositoryTest
    {
        private DbConnection dbConn;
        private UserAddressRepository myRepo;

        [TestInitialize]
        public void SetUp()
        {
            dbConn = new DbConnection();
            myRepo = new UserAddressRepository(dbConn);
        }

        [TestMethod]
        public void Add_Delete_Update_Success()
        {
            var addTarget = new UserAddress
            {
                ID = "URA0123",
                UserID = "USR0001",
                Details = "tra vinh xom A"
            };
            bool isAddSuccess = myRepo.Add(addTarget);
            var addResult = myRepo.SearchByID(addTarget.ID);

            // Do not modify the ID
            var updateTarget = new UserAddress
            {
                ID = addTarget.ID,
                UserID = "USR0002",
                Details = "tra vinh xom B"
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

        private void AssertObj(UserAddress expected, UserAddress actual)
        {
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.ID, actual.ID);
            Assert.AreEqual(expected.UserID, actual.UserID);
            Assert.AreEqual(expected.Details, actual.Details);
        }
    }
}
