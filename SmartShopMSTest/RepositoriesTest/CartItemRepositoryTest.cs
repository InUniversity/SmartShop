using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartShop.Database;
using SmartShop.Models;
using SmartShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartShop.ConvertToModel;
using SmartShop.Queries;

namespace SmartShopMSTest.RepositoriesTest
{
    [TestClass]
    public class CartItemRepositoryTest
    {
        private DbConnection dbConn;
        private CartItemRepository myRepo;

        [TestInitialize]
        public void SetUp()
        {
            dbConn = new DbConnection();
            var convModelFactory = new ConvModelFactory();
            var dbConv = new DbConverter(convModelFactory);
            var query = new CartItemQuery();
            myRepo = new CartItemRepository(dbConn, dbConv, query);
        }

        [TestMethod]
        public void Add_Delete_Update_Success()
        {
            var addTarget = new CartItem
            {
                ID = "CAI001245",
                UserID = "USR0001",
                ProdID = "PRO0001",
                Quantity = 2 
            };
            bool isAddSuccess = myRepo.Add(addTarget);
            var addResult = myRepo.SearchByID(addTarget.ID);

            // Do not modify the ID
            var updateTarget = new CartItem
            {
                ID = addTarget.ID,
                UserID = "USR0001",
                ProdID = "PRO0001",
                Quantity = 10
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

        private void AssertObj(CartItem expected, CartItem actual)
        {
            Assert.AreEqual(expected.ID, actual.ID);
            Assert.AreEqual(expected.UserID, actual.UserID);
            Assert.AreEqual(expected.ProdID, actual.ProdID);
            Assert.AreEqual(expected.Quantity, actual.Quantity);
        }
    }
}
