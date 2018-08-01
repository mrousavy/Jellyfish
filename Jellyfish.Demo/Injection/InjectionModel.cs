using Jellyfish.DependencyInjection;

namespace Jellyfish.Demo.Injection
{
    public class InjectionModel
    {
        private IInjector Injector { get; }

        public InjectionModel()
        {
            Injector = new Injector();
        }

        public IUser TemplateUser()
        {
            Injector.Register<IUser>(() => new User());
            return Injector.Initialize<IUser>();
        }

        public IUser DefineUser()
        {
            Injector.Register<IUser>(new User());
            return Injector.Initialize<IUser>();
        }

        public IUser BindUser()
        {
            Injector.Register<IUser, User>();
            return Injector.Initialize<IUser>();
        }
    }
}