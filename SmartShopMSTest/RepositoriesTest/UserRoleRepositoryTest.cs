using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartShop.Database;
using SmartShop.Repositories;
using SmartShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartShop.ConvertToModel;

namespace SmartShopMSTest.RepositoriesTest
{
    [TestClass]
    public class UserRoleRepositoryTest
    {
        private DbConnection dbConn;
        private UserRoleRepository myRepo;

        [TestInitialize]
        public void SetUp()
        {
            dbConn = new DbConnection();
            var convModelFactory = new ConvModelFactory();
            var dbConv = new DbConverter(convModelFactory);
            myRepo = new UserRoleRepository(dbConn, dbConv);
        }

        [TestMethod]
        public void Add_Delete_Update_Success()
        {
            var addTarget = new UserRole
            {
                ID = "PRO1234",
                Name = "manager"
            };
            bool isAddSuccess = myRepo.Add(addTarget);
            var addResult = myRepo.SearchByID(addTarget.ID);

            // Do not modify the ID
            var updateTarget = new UserRole
            {
                ID = addTarget.ID,
                Name = "employee"
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

        private void AssertObj(UserRole expected, UserRole actual)
        {
            Assert.AreEqual(expected.ID, actual.ID);
            Assert.AreEqual(expected.Name, actual.Name);

        }
    }
}
