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
    public class OrderRepositoryTest
    {
        private DbConnection dbConn;
        private OrderRepository myRepo;

        [SetUp]
        public void SetUp()
        {
            dbConn = new DbConnection();
            myRepo = new OrderRepository(dbConn);
        }

        [Test]
        public void Add_Delete_Update_Success()
        {
            var addTarget = new Order
            {
                ID = "PRO1234",
                UserID = "",
                ProductID = "",
                OrderStatusID="",
                //OrderDate = '2022-02-02',
                TotalPrice = (decimal)101230.12
            };
            bool isAddSuccess = myRepo.Add(addTarget);
            var addResult = myRepo.SearchByID(addTarget.ID);

            // Do not modify the ID
            var updateTarget = new Order
            {
                ID = addTarget.ID,
                UserID = "",
                ProductID = "",
                OrderStatusID = "",
                //OrderDate = '2022-02-02',
                TotalPrice = (decimal)101230.12
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
