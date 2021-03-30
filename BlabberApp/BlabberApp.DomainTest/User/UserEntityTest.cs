using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain;

namespace BlabberApp.DomainTest
{
    [TestClass]
    public class UserEntityTest
    {
        [TestMethod]
        public void TestInvalidID()
        {
            // arrange
            var harness = new UserEntity();
            var expected = "foobar";
            // act assert
            Assert.ThrowsException<FormatException>(() => harness.SetId(expected));
        }
        [TestMethod]
        public void TestValidID()
        {
            // arrange
            var harness = new UserEntity();
            var expected = "me@example.com";
            // act
            harness.SetId("me@example.com");
            // assert
            Assert.AreEqual(expected, harness.GetId());
        }
    }
}
