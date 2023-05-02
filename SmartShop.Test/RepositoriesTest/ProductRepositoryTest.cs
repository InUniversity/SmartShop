using NUnit.Framework;
using SmartShop.Database;
using SmartShop.Models;
using SmartShop.Repositories;

namespace SmartShop.Test.RepositoriesTest
{
    [TestFixture]
    public class ProductRepositoryTest
    {
        private DbConnection dbConn;
        private ProductRepository myRepo;

        [SetUp]
        public void SetUp()
        {
            dbConn = new DbConnection();
            myRepo = new ProductRepository(dbConn);
        }

        [Test]
        public void Product_Repository_Add_Delete_Update_Test()
        {
            var addTarget = new Product { ID = "PRO1234", CategoryID = "CAT124", ImgUrl = "", 
                Name = "ip xxx", Price = (decimal)101230.12, Quantity = 10, Description = "Kha ổn"};
            bool isAddSuccess = myRepo.Add(addTarget);
            var addResult = myRepo.SearchByID(addTarget.ID);

            // Do not modify the ID
            var updateTarget = new Product { ID = addTarget.ID, CategoryID = "CAT127", ImgUrl =  addTarget.ImgUrl + ".",
                Name = "ip xsmax", Price = (decimal)111111.12, Quantity = 44, Description = "Qua ổn" };
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

        private void AssertObj(Product expected, Product actual)
        {
            Assert.AreEqual(expected.ID, actual.ID);
            Assert.AreEqual(expected.CategoryID, actual.CategoryID);
            Assert.AreEqual(expected.ImgUrl, actual.ImgUrl);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Price, actual.Price);
            Assert.AreEqual(expected.Quantity, actual.Quantity);
            Assert.AreEqual(expected.Description, actual.Description);
        }
    }
}