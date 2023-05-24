﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartShop.Database;
using SmartShop.Models;
using SmartShop.Repositories;
using System;

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
                StatusID = "ORDERS0001",
                Date = new DateTime(2022, 2, 2, 0, 0, 0)
            };
            bool isAddSuccess = myRepo.Add(addTarget);
            var addResult = myRepo.SearchByID(addTarget.ID);

            // Do not modify the ID
            var updateTarget = new Order
            {
                ID = addTarget.ID,
                UserID = "USER0001",
                StatusID = "ORDERS0001",
                Date = new DateTime(2022, 2, 2, 0, 0, 0)
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

        [DataTestMethod]
        [DataRow("OR0001", 500.0, DisplayName = "Test1")]
        [DataRow("OR0002", 20.0, DisplayName = "Test2")]
        [DataRow("OR0003", 200.0, DisplayName = "Test3")]
        public void GetTotalPrice(string orderID, double expected)
        {
            decimal actual = myRepo.GetTotalPrice(orderID);
            
            Assert.AreEqual((decimal)expected, actual);
        }

        private void AssertObj(Order expected, Order actual)
        {
            Assert.AreEqual(expected.ID, actual.ID);
            Assert.AreEqual(expected.UserID, actual.UserID);
            Assert.AreEqual(expected.StatusID, actual.StatusID);
            Assert.AreEqual(expected.Date.ToString(), actual.Date.ToString());
        }
    }
}
