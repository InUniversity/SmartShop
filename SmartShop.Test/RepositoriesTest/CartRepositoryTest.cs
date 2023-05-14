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
    public class CartRepositoryTest
    {
        private DbConnection dbConn;
        private CartRepository myRepo;

        [SetUp]
        public void SetUp()
        {
            dbConn = new DbConnection();
            myRepo = new CartRepository(dbConn);
        }

        [Test]
        public void Add_Delete_Update_Success()
        {
            var addTarget = new Cart
            {
                ID = "CART1234",
                UserID ="USER1234",
                TotalPrice = (decimal)101230.12,
                //UpdateAt = '2022-02-02 00:00:00'
            };
            bool isAddSuccess = myRepo.Add(addTarget);
            var addResult = myRepo.SearchByID(addTarget.ID);

            // Do not modify the ID
            var updateTarget = new Cart
            {
                ID = addTarget.ID,
                UserID = "USER2546",
                TotalPrice = (decimal)101230.12,
                //UpdateAt = '2055-02-02 00:00:00'
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

        private void AssertObj(Cart expected, Cart actual)
        {
            Assert.AreEqual(expected.ID, actual.ID);
            Assert.AreEqual(expected.UserID, actual.UserID);
            Assert.AreEqual(expected.TotalPrice, actual.TotalPrice);
            Assert.AreEqual(expected.UpdateAt, actual.UpdateAt);
        }
    }
}
