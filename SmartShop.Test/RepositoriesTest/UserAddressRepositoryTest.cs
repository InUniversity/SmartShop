using NUnit.Framework;
using SmartShop.Models;
using SmartShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartShop.Database;

namespace SmartShop.Test.RepositoriesTest
{
    [TestFixture]
    public class UserAddressRepositoryTest
    {
        private DbConnection dbConn;
        private UserAddressRepository myRepo;

        [SetUp]
        public void SetUp()
        {
            dbConn = new DbConnection();
            myRepo = new UserAddressRepository(dbConn);
        }

        [Test]
        public void Add_Delete_Update_Success()
        {
            var addTarget = new UserAddress
            {
                ID = "Ad123",
                UserID = "USER123",
                Details = "tra vinh xom A"
            };
            bool isAddSuccess = myRepo.Add(addTarget);
            var addResult = myRepo.SearchByID(addTarget.ID);

            // Do not modify the ID
            var updateTarget = new UserAddress
            {
                ID = addTarget.ID,
                UserID = "USER123",
                Details = "tra vinh xom A"
            };
            bool isUpdateSuccess = myRepo.Update(updateTarget);
            var updateResult = myRepo.SearchByID(addTarget.ID);

            myRepo.Delete(addTarget.ID);
            var deleteResult = myRepo.SearchByID(addTarget.ID);

            // test add
            Assert.True(isAddSuccess);
            AssertObj(addTarget, addResult);

            // test update
            Assert.True(isUpdateSuccess);
            AssertObj(updateTarget, updateResult);

            // test delete
            Assert.Null(deleteResult);
        }

        private void AssertObj(UserAddress expected, UserAddress actual)
        {
            Assert.AreEqual(expected.ID, actual.ID);
            Assert.AreEqual(expected.UserID, actual.UserID);
            Assert.AreEqual(expected.Details, actual.Details);            
        }
    }
}
