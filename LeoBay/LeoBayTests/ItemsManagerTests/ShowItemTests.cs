using System;
using System.Collections.Generic;
using System.Text;
using LeoBayController;
using LeoBayController.ItemsManagerController;
using NUnit.Framework;
using LeoBayModel;

namespace LeoBayTests.ItemsManagerTests
{
    public class ShowItemTests
    {
        private ItemsManagerController _itemsManagerController = new ItemsManagerController();
        private TestingMethods _testingMethods = new TestingMethods();

        [Test]
        public void AddNewItem()
        {

            CurrentUser.Id = 1;
            //arrange
            var count = _itemsManagerController.GetAllItems().Count;
            // act
            _itemsManagerController.AddNewItem(name:"Guitar", price:50, description:"2 years old", image: "guitar");
            // assert
            var newCount = _itemsManagerController.GetAllItems().Count;
            Assert.AreEqual(count + 1, newCount);
            // restore
            _testingMethods.DeleteItem();
        }

        [Test]
        public void GetAllItems()
        {
            List<Product> result = new List<Product>() { new Product() { ProductId = 1, ProductName = "Test" } };

            var actual = _itemsManagerController.GetAllItems();
            Assert.AreEqual(result[0].ProductId, 1);
            Assert.AreEqual(result[0].ProductName, "Test");
        }

        [Test]
        public void GetCurrentItems()
        {
            List<Product> result = new List<Product>() { new Product() { ProductId = 1, ProductName = "Test" } };
            CurrentUser.Id = 1;
            var actual = _itemsManagerController.GetCurrentUserItems();
            Assert.AreEqual(result[0].ProductId, 1);
            Assert.AreEqual(result[0].ProductName, "Test");
            CurrentUser.Id = 0;
        }
    }
}
