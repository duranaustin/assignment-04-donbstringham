using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore;
using BlabberApp.Domain;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class InMemoryTest
    {
        [TestMethod]
        public void TestCanary()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestConstructorSuccess()
        {
            // arrange act
            var expected = new InMemory();
            var actual = new InMemory();
            // assert
            Assert.AreEqual(expected.Count(), actual.Count());
        }
        [TestMethod]
        public void TestConstructorFailure()
        {
            // arrange
            var expected = new InMemory();
            var actual = new InMemory();
            // act
            actual.Add(new UserEntity());
            actual.Add(new BlabEntity());
            // assert
            Assert.AreNotEqual(expected.Count(), actual.Count());
        }
        [TestMethod]
        public void TestConstructorOverrideSuccess()
        {
            // arrange
            UserEntity[] users = {
                new UserEntity(),
                new UserEntity(),
                new UserEntity(),
                new UserEntity()
            };
            var expected = 4;
            // act
            var fixture = new InMemory(users);
            var actual = fixture.Count();
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCountSuccess()
        {
            // arrange
            var expected = 1;
            var fixture = new InMemory();
            // act
            fixture.Create(new UserEntity());
            var actual = fixture.Count();
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestRemoveSuccess()
        {
            // arrange
            var fixture = new InMemory();
            var expected = 0;
            var usr = new UserEntity();
            usr.SetId("foobar@usa.us");
            // act
            fixture.Create(usr);
            var actual = fixture.Count();
            Assert.AreEqual(1, actual);
            fixture.Remove("foobar@usa.us");
            actual = fixture.Count();
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRemoveFailure()
        {
            // arrange
            var fixture = new InMemory();
            var usr = new UserEntity();
            usr.SetId("foobar@usa.us");
            // act assert
            fixture.Create(usr);
            var actual = fixture.Count();
            Assert.AreEqual(1, actual);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => fixture.Remove("foobar@usa.com"));
        }

        [TestMethod]
        public void TestRemoveFailure2()
        {
            // arrange
            var fixture = new InMemory();
            // act assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => fixture.Remove("foobar@usa.com"));
        }

        [TestMethod]
        public void TestFindSuccess()
        {
            // arrange
            var fixture = new InMemory();
            var expected = new UserEntity();
            expected.SetId("foobar@usa.us");
            // act
            fixture.Create(expected);
            var actual = fixture.Find("foobar@usa.us");
            // assert
            Assert.AreEqual(expected.GetId(), actual.GetId());
        }

        [TestMethod]
        public void TestFindFailure()
        {
            // arrange
            var fixture = new InMemory();
            // act assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => fixture.Remove("foobar@usa.com"));
        }

        [TestMethod]
        public void TestUpdateSuccess()
        {
            // arrange
            var fixture = new InMemory();
            var expected = new UserEntity();
            expected.SetId("foobar@usa.us");
            expected.Name = "fubar";
            // act
            fixture.Create(expected);
            expected.Name = "foobar";
            fixture.Update(expected);
            var actual = fixture.Find("foobar@usa.us"); 
            // assert
            Assert.AreEqual(expected.GetId(), actual.GetId());
        }
        [TestMethod]
        public void TestUpdateSuccess2()
        {
            // arrange
            var fixture = new InMemory();
            var expected = new UserEntity();
            var actual = new UserEntity();
            expected.SetId("foobar@usa.us");
            expected.Name = "foobar";
            actual.SetId("foobar@usa.us");
            actual.Name = "Willy Wonka";
            // act
            fixture.Create(expected);
            fixture.Update(actual);
            actual = (UserEntity)fixture.Find("foobar@usa.us");
            // assert
            Assert.AreEqual("Willy Wonka", actual.Name);
        }

        [TestMethod]
        public void TestUpdateFailure()
        {
            // arrange
            var fixture = new InMemory();
            var expected = new UserEntity();
            var actual = new UserEntity();
            expected.SetId("foobar@usa.us");
            expected.Name = "fubar";
            actual.SetId("willy@wonka.com");
            actual.Name = "Willy Wonka";
            // act
            fixture.Create(expected);
            // assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>fixture.Update(actual));
        }
    }
}
