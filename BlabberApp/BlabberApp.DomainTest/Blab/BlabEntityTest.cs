using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain;

namespace BlabberApp.DomainTest
{
    [TestClass]
    public class BlabEntityTest
    {
        [TestMethod]
        public void TestCanary()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestConstructorArgument()
        {
            // arrange
            var fixture = new BlabEntity("foobar");
            var expected = "foobar";
            // act
            var actual = fixture.Msg;
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestID()
        {
            // arrange
            var fixture = new BlabEntity();
            Type t = typeof(string);
            // act
            var actual = fixture.GetId();
            // assert
            Assert.IsInstanceOfType(actual, t);
            Assert.IsTrue(Guid.TryParse(actual, out Guid g));
        }
    }
}