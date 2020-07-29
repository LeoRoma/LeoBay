using System;
using System.Collections.Generic;
using System.Text;
using LeoBayController;
using LeoBayController.ItemsManagerController;
using NUnit.Framework;
using LeoBayModel;

namespace LeoBayTests.EncryptionTests
{
    public class EncryptionTests
    {
        private Encryption _encryption = new Encryption();

        [Test]
        public void TestingEncrptionMethod()
        {
            var actual = _encryption.Encrypt("123");
            var result = "PV0yzuraq6f+DRhS5iehlQ==";
            Assert.AreEqual(result, actual);
        }

        [Test]
        public void TestingDecrptionMethod()
        {
            var actual = _encryption.Decrypt("PV0yzuraq6f+DRhS5iehlQ==");
            var result = "123";
            Assert.AreEqual(result, actual);
        }
    }
}
