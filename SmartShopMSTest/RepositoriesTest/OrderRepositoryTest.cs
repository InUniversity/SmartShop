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
    public class OrderRepositoryTest
    {
        private DbConnection dbConn;
        private OrderRepository myRepo;

        [TestInitialize]
        public void SetUp()
        {
            dbConn = new DbConnection();
            myRepo = new OrderRepository(dbConn);
        }

        [TestMethod]
        public void Add_Delete_Update_Success()
        {
            var addTarget = new Order
            {
                ID = "PRO44333",
                UserID = "USER0001",
                ProductID = "",
                OrderStatusID = "ORDERS0001",
                OrderDate = new DateTime(2022, 2, 2, 0, 0, 0),
                TotalPrice = (decimal)1.12
            };
            bool isAddSuccess = myRepo.Add(addTarget);
            var addResult = myRepo.SearchByID(addTarget.ID);

            // Do not modify the ID
            var updateTarget = new Order
            {
                ID = addTarget.ID,
                UserID = "USER0001",
                ProductID = "",
                OrderStatusID = "ORDERS0001",
                OrderDate = new DateTime(2022, 2, 2, 0, 0, 0),
                TotalPrice = (decimal)1.12
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

        private void AssertObj(Order expected, Order actual)
        {
            Assert.AreEqual(expected.ID, actual.ID);
            Assert.AreEqual(expected.UserID, actual.UserID);
            Assert.AreEqual(expected.OrderStatusID, actual.OrderStatusID);
            Assert.AreEqual(expected.OrderDate, actual.OrderDate);
            Assert.AreEqual(expected.TotalPrice, actual.TotalPrice);
        }
    }
}
