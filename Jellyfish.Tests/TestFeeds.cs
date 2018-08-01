using System;
using Jellyfish.Feeds;
using Jellyfish.Tests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jellyfish.Tests
{
    [TestClass]
    public class TestFeeds : IFeedNode<IUser>
    {
        [TestMethod]
        public void TestAddUser()
        {
            var usersWindow = new UsersWindow();

            int countBefore = usersWindow.Users.Count;

            var newUser = new User("John", "Smith");
            this.Notify(newUser);

            int countAfter = usersWindow.Users.Count;
            Assert.IsTrue(countAfter > countBefore);
        }

        [TestMethod]
        public void TestAddUserInterface()
        {
            var usersWindow = new UsersWindow();

            int countBefore = usersWindow.Users.Count;

            IUser newUser = new User("John", "Smith");
            this.Notify(newUser);

            int countAfter = usersWindow.Users.Count;
            Assert.IsTrue(countAfter > countBefore);
        }

        [TestMethod]
        public void TestAddWrongType()
        {
            var usersWindow = new UsersWindow();

            int countBefore = usersWindow.Users.Count;

            var newUser = new Tuple<string, string>("John", "Smith");
            MessageFeed<Tuple<string, string>>.Feed.Notify(newUser);

            int countAfter = usersWindow.Users.Count;
            Assert.AreEqual(countAfter, countBefore);
        }

        [TestMethod]
        public void TestAddUserMultiple()
        {
            var usersWindow1 = new UsersWindow();
            var usersWindow2 = new UsersWindow();

            int countBefore1 = usersWindow1.Users.Count;
            int countBefore2 = usersWindow2.Users.Count;

            var newUser = new User("John", "Smith");
            this.Notify(newUser);

            int countAfter1 = usersWindow1.Users.Count;
            int countAfter2 = usersWindow2.Users.Count;

            Assert.AreEqual(countBefore1, countBefore2);
            Assert.AreEqual(countAfter1, countAfter2);
            Assert.IsTrue(countAfter1 > countBefore1);
        }

        public void MessageReceived(IUser message)
        {
            // do nothing
        }
    }
}
