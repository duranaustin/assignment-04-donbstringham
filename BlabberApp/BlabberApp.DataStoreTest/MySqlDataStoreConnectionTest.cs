using BlabberApp.DataStore;
using BlabberApp.Domain;
using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class MySqlDataStoreConnectionTest
    {
        [TestMethod]
        public void TestCanary()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestConstructor()
        {
            // arrange
            MySqlDataStoreConnection fixture = new MySqlDataStoreConnection(
                "Server=143.110.159.170;Port=3306;Database=donstringham;Uid=donstringham;Pwd=letmein;"
            );
            // act & assert
            try
            {
                fixture.Open();
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
            try
            {
                fixture.Close();
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
        [TestMethod]
        public void TestCreateCommand()
        {
            // arrange
            MySqlDataStoreConnection fixture = new MySqlDataStoreConnection(
                "Server=143.110.159.170;Port=3306;Database=donstringham;Uid=donstringham;Pwd=letmein;"
            );
            // act
            var actual = fixture.CreateCommand();
            // assert
            Assert.IsTrue(actual is IDbCommand);
        }
    }
}
