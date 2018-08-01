using Jellyfish.DependencyInjection;
using Jellyfish.Tests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jellyfish.Tests
{
    [TestClass]
    public class TestInjector
    {
        private IInjector Injector { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            Injector = new Injector();
        }

        [TestMethod]
        public void TestInjectorBindingNotNull()
        {
            Injector.Clear();

            // define a binding which will locate the default ctor
            Injector.Register<IUser, User>();
            var user = Injector.Initialize<IUser>();
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void TestInjectorBindingDefaultConstructor()
        {
            Injector.Clear();

            // define a binding which will locate the default ctor
            Injector.Register<IUser, User>();
            var user = Injector.Initialize<IUser>();

            // because the default ctor was called, these fields should be null
            Assert.IsNull(user.FirstName);
            Assert.IsNull(user.LastName);
        }

        [TestMethod]
        public void TestInjectorTemplateNotNull()
        {
            Injector.Clear();

            // define a template/macro for user creation
            Injector.Register<IUser>(() => new User());
            var user = Injector.Initialize<IUser>();
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void TestInjectorTemplateCorrectParams()
        {
            Injector.Clear();

            const string firstName = "John";
            const string lastName = "Smith";
            // define a template/macro for user creation
            Injector.Register<IUser>(() => new User(firstName, lastName));
            var user = Injector.Initialize<IUser>();
            Assert.AreEqual(firstName, user.FirstName);
            Assert.AreEqual(lastName, user.LastName);
        }

        [TestMethod]
        public void TestInjectorDefineNotNull()
        {
            Injector.Clear();

            // define static user in injector
            var definedUser = new User("John", "Smith");
            Injector.Register<IUser>(definedUser);

            // get user from injector
            var user = Injector.Initialize<IUser>();
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void TestInjectorDefineEqualsOriginal()
        {
            Injector.Clear();

            // define static user in injector
            var definedUser = new User("John", "Smith");
            Injector.Register<IUser>(definedUser);

            // compare user from injector to original
            var user = Injector.Initialize<IUser>();
            Assert.AreEqual(definedUser, user);
        }
    }
}