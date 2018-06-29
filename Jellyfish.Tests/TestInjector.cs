using Jellyfish.DependencyInjection;
using Jellyfish.Tests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jellyfish.Tests
{
    [TestClass]
    public class TestInjector
    {
        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public void TestInjectorBindingNotNull()
        {
            Injector.Clear();

            // define a binding which will locate the default ctor
            Injector.Bind<IUser, User>();
            var user = Injector.Initialize<IUser>();
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void TestInjectorBindingDefaultConstructor()
        {
            Injector.Clear();

            // define a binding which will locate the default ctor
            Injector.Bind<IUser, User>();
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
            Injector.Template<IUser>(() => new User());
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
            Injector.Template<IUser>(() => new User(firstName, lastName));
            var user = Injector.Initialize<IUser>();
            Assert.Equals(user.FirstName, firstName);
            Assert.Equals(user.LastName, lastName);
        }

        [TestMethod]
        public void TestInjectorDefineNotNull()
        {
            Injector.Clear();

            // define static user in injector
            var definedUser = new User("John", "Smith");
            Injector.Define<IUser>(definedUser);

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
            Injector.Define<IUser>(definedUser);

            // compare user from injector to original
            var user = Injector.Initialize<IUser>();
            Assert.Equals(user, definedUser);
        }
    }
}
