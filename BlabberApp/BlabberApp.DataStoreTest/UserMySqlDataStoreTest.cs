using System;
using BlabberApp.DataStore;
using BlabberApp.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class UserMySqlDataStoreTest
    {
        [TestMethod]
        public void TestCanary()
        {
            Assert.IsTrue(true);
        }   
        [TestMethod]
        public void TestCreateSuccess()
        {
            // arrange
            var expected = new UserEntity();
            var fixture = new UserMySqlDataStore(new MySqlDataStoreConnection(
                "Server=143.110.159.170;Port=3306;Database=donstringham;Uid=donstringham;Pwd=letmein;"
            ));
            // act and assert
            Assert.ThrowsException<NotImplementedException>(() => fixture.Create(expected));
        }   
        [TestMethod]
        public void TestDeleteSuccess()
        {
            // arrange
            var fixture = new UserMySqlDataStore(new MySqlDataStoreConnection(
                "Server=143.110.159.170;Port=3306;Database=donstringham;Uid=donstringham;Pwd=letmein;"
            ));
            // act and assert
            Assert.ThrowsException<NotImplementedException>(() => fixture.Delete("0-0-0-0-0"));
        }   
        [TestMethod]
        public void TestReadSuccess()
        {
            // arrange
            var expected = new UserEntity();
            var fixture = new UserMySqlDataStore(new MySqlDataStoreConnection(
                "Server=143.110.159.170;Port=3306;Database=donstringham;Uid=donstringham;Pwd=letmein;"
            ));
            // act and assert
            Assert.ThrowsException<NotImplementedException>(() => fixture.Read("0-0-0-0-0"));
        }   
        [TestMethod]
        public void TestReadEmpty()
        {
            // arrange
            var expected = new UserEntity();
            var fixture = new UserMySqlDataStore(new MySqlDataStoreConnection(
                "Server=143.110.159.170;Port=3306;Database=donstringham;Uid=donstringham;Pwd=letmein;"
            ));
            // act
            UserEntity actual = (UserEntity)fixture.Read("0a23f006-3631-44d0-bf12-cabb03aee11d");
            // assert
            Assert.AreEqual(expected.Name, actual.Name);
        }   
        [TestMethod]
        public void TestReadAllSuccess()
        {
            // arrange
            MySqlDataStoreConnection conn = new MySqlDataStoreConnection(
                "Server=143.110.159.170;Port=3306;Database=donstringham;Uid=donstringham;Pwd=letmein;"
            );
            UserMySqlDataStore fixture = new UserMySqlDataStore(conn);
            var Expected = typeof(IDomain[]);
            // act
            IDomain[] actual = fixture.ReadAll();
            // assert
            Assert.IsInstanceOfType(actual, Expected);
            Assert.AreEqual(0, actual.Length);
        }
        [TestMethod]
        public void TestReadAllOneRecord()
        {
            // arrange
            MySqlDataStoreConnection conn = new MySqlDataStoreConnection(
                "Server=143.110.159.170;Port=3306;Database=donstringham;Uid=donstringham;Pwd=letmein;"
            );
            UserMySqlDataStore fixture = new UserMySqlDataStore(conn);
            UserEntity usr = new UserEntity();
            usr.SetId("example@example.com");
            usr.Name = "Example";
            var Expected = typeof(IDomain[]);
            // act
            fixture.Create(usr);
            IDomain[] actual = fixture.ReadAll();
            // assert
            Assert.IsInstanceOfType(actual, Expected);
            Assert.AreEqual(1, actual.Length);

            fixture.DeleteAll();
        }
        [TestMethod]
        public void TestDeleteAll()
        {
            // arrange
            MySqlDataStoreConnection conn = new MySqlDataStoreConnection(
                "Server=143.110.159.170;Port=3306;Database=donstringham;Uid=donstringham;Pwd=letmein;"
            );
            UserMySqlDataStore fixture = new UserMySqlDataStore(conn);
            // act
            fixture.DeleteAll();
            var actual = fixture.ReadAll();
            // assert
            Assert.AreEqual(0, actual.Length);
        }
        [TestMethod]
        public void TestUpdateSuccess()
        {
            // arrange
            var expected = new UserEntity();
            var fixture = new UserMySqlDataStore(new MySqlDataStoreConnection(
                "Server=143.110.159.170;Port=3306;Database=donstringham;Uid=donstringham;Pwd=letmein;"
            ));
            // act and assert
            Assert.ThrowsException<NotImplementedException>(() => fixture.Update(expected));
        }   
    }
}