using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using LeoBayController;
using LeoBayModel;
using System.Linq;

namespace LeoBayTests.CheckoutControllerTests
{
    public class CheckoutControllerTests
    {
        private TestingMethods _testingMethods = new TestingMethods();

        //[Test]
        public void CreateANewOrder()
        {
            //var count = _testingMethods.GetOrder().Count;
            //_testingMethods.AddToCart();
            //var newCount = _testingMethods.GetUser().Count;
            //Assert.AreEqual(count + 1, newCount);

            _testingMethods.DeleteOrder();
        }

    }
}
