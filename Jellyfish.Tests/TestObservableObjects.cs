using Jellyfish.Tests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jellyfish.Tests
{

    [TestClass]
    public class TestObservableObjects
    {
        public User User { get; private set; }

        [TestInitialize]
        public void Initialize()
        {
            User = new User();
        }

        [TestMethod]
        public void TestPropertyChangedRaised()
        {
            int raisedCount = 0;
            // set `raised` to true on property changed
            User.PropertyChanged += (s, a) => { raisedCount++; };
            // change a property so effectively raise property changed event
            User.Name = "Marc";

            // not more than 1 and not less than 1
            Assert.IsTrue(raisedCount == 1);
        }

        [TestMethod]
        public void TestPropertyDoesntRaiseOnSameValue()
        {
            int raisedCount = 0;
            // set `raised` to true on property changed
            User.PropertyChanged += (s, a) => { raisedCount++; };
            // assign the property twice
            const string value = "Test";
            User.Name = value;
            User.Name = value;

            // not more than 1 and not less than 1
            Assert.IsTrue(raisedCount == 1);
        }

        [TestMethod]
        public void TestPropertyAcceptsNull()
        {
            int raisedCount = 0;
            // set `raised` to true on property changed
            User.PropertyChanged += (s, a) => { raisedCount++; };
            // change a property to null so effectively raise property changed event
            User.Name = null;

            // not more than 1 and not less than 1
            Assert.IsTrue(raisedCount == 1);
        }
    }
}
