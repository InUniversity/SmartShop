using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartShop.Database;
using SmartShop.Models;
using SmartShop.Repositories;
using SmartShop.ConvertToModel;

namespace SmartShopMSTest.RepositoriesTest
{
    [TestClass]
    public class OrderStatusRepositoryTest
    {
        private DbConnection dbConn;
        private OrderStatusRepository myRepo;

        [TestInitialize]
        public void SetUp()
        {
            dbConn = new DbConnection();
            var convModelFactory = new ConvModelFactory();
            var dbConv = new DbConverter(convModelFactory);
            myRepo = new OrderStatusRepository(dbConn, dbConv);
        }

        [TestMethod]
        public void Add_Delete_Update_Success()
        {
            var addTarget = new OrderStatus
            {
                ID = "ORS0123",
                Name = "hoatdong"
            };
            bool isAddSuccess = myRepo.Add(addTarget);
            var addResult = myRepo.SearchByID(addTarget.ID);

            // Do not modify the ID
            var updateTarget = new OrderStatus
            {
                ID = addTarget.ID,
                Name = "khonghoatdong"
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

        private void AssertObj(OrderStatus expected, OrderStatus actual)
        {
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.ID, actual.ID);
            Assert.AreEqual(expected.Name, actual.Name);
        }
    }
}
