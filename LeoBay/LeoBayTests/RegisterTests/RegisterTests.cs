using NUnit.Framework;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using LeoBayController;
using LeoBayModel;

namespace LeoBayTests
{
    public class RegisterTests
    {
        private RegisterController _registerController = new RegisterController();
        private LoginController _loginController = new LoginController();
        private TestingMethods _testingMethods = new TestingMethods();

        [SetUp]
        public void Setup()
        {
            _testingMethods.AuthenticateUser("leo@gmail.com", "123");
        }

        [Test]
        public void CreateANewUser()
        {
            //arrange
            var count = _testingMethods.GetUser().Count;
            // act
            _registerController.CreateNewUser("Harry", "Derbyshire", "harry@gmail.com", "123");
            // assert
            var newCount = _testingMethods.GetUser().Count;
            Assert.AreEqual(count + 1, newCount);
            // restore
            _testingMethods.DeleteUser();     
        }

        [Test]
        public void AuthenticateLoggingUser()
        {
            var actual = _testingMethods.AuthenticateUser("leo@gmail.com", "PV0yzuraq6f+DRhS5iehlQ==");
            var result = true;
            Assert.AreEqual(result, actual);
        }

        //[Test]
        //public void SetCurrentUserAfterLoggedIn()
        //{
        //    var actual = _testingMethods.AuthenticateUser("alex@gmail.com", "123");
        //    var currentUser = new CurrentUser() { CurrentUserId = 2, CurrentFirstName = "Alex", CurrentLastName = "Matheakis", CurrentEmail = "alex@gmail.com" };
        //    Assert.AreEqual(currentUser, actual);
        //}
    }
}