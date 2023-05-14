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
    public class UserRoleRepositoryTest
    {
        private DbConnection dbConn;
        private UserRoleRepository myRepo;

        [SetUp]
        public void SetUp()
        {
            dbConn = new DbConnection();
            myRepo = new UserRoleRepository(dbConn);
        }

        [Test]
        public void Add_Delete_Update_Success()
        {
            var addTarget = new UserRole
            {
                ID = "PRO1234",
                RoleName = "manager"
            };
            bool isAddSuccess = myRepo.Add(addTarget);
            var addResult = myRepo.SearchByID(addTarget.ID);

            // Do not modify the ID
            var updateTarget = new UserRole
            {
                ID = addTarget.ID,
                RoleName = "employee"
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

        private void AssertObj(UserRole expected, UserRole actual)
        {
            Assert.AreEqual(expected.ID, actual.ID);
            Assert.AreEqual(expected.RoleName, actual.RoleName);

        }
    }
}
