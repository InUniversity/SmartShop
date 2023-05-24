using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartShop.ConvertToModel;
using SmartShop.Database;
using SmartShop.Models;
using SmartShop.Repositories;

namespace SmartShop.Test.RepositoriesTest
{
    [TestClass]
    public class ProductRepositoryTest
    {
        private DbConnection dbConn;
        private ProductRepository myRepo;

        [TestInitialize]
        public void SetUp()
        {
            dbConn = new DbConnection();
            var convModelFactory = new ConvModelFactory();
            var dbConv = new DbConverter(convModelFactory);
            myRepo = new ProductRepository(dbConn, dbConv);
        }

        [TestMethod]
        public void Add_Delete_Update_Success()
        {
            var addTarget = new Product { ID = "PRO1234", CategoryID = "CTG0001", ImgUrl = "", 
                Name = "ip xxx", Price = (decimal)101230.12, Quantity = 10, Desc = "Kha ổn"};
            bool isAddSuccess = myRepo.Add(addTarget);
            var addResult = myRepo.SearchByID(addTarget.ID);

            // Do not modify the ID
            var updateTarget = new Product { ID = addTarget.ID, CategoryID = "CTG0002", ImgUrl =  addTarget.ImgUrl + ".",
                Name = "ip xsmax", Price = (decimal)111111.12, Quantity = 44, Desc = "Qua ổn" };
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

        private void AssertObj(Product expected, Product actual)
        {
            Assert.AreEqual(expected.ID, actual.ID);
            Assert.AreEqual(expected.CategoryID, actual.CategoryID);
            Assert.AreEqual(expected.ImgUrl, actual.ImgUrl);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Price, actual.Price);
            Assert.AreEqual(expected.Quantity, actual.Quantity);
            Assert.AreEqual(expected.Desc, actual.Desc);
        }
    }
}