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
    public class CartItemRepositoryTest
    {
        private DbConnection dbConn;
        private CartItemRepository myRepo;

        [SetUp]
        public void SetUp()
        {
            dbConn = new DbConnection();
            myRepo = new CartItemRepository(dbConn);
        }

        [Test]
        public void Add_Delete_Update_Success()
        {
            var addTarget = new CartItem
            {
                ID = "CARTIT1234",
                CartID = "CART1235",
                ProductID = "PROD456",
                Quantity = 1               
            };
            bool isAddSuccess = myRepo.Add(addTarget);
            var addResult = myRepo.SearchByID(addTarget.ID);

            // Do not modify the ID
            var updateTarget = new CartItem
            {
                ID = addTarget.ID,
                CartID = "CART1289",
                ProductID = "PROD245",
                Quantity = 10
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

        private void AssertObj(CartItem expected, CartItem actual)
        {
            Assert.AreEqual(expected.ID, actual.ID);
            Assert.AreEqual(expected.CartID, actual.CartID);
            Assert.AreEqual(expected.ProductID, actual.ProductID);
            Assert.AreEqual(expected.Quantity, actual.Quantity);
        }
    }
}
