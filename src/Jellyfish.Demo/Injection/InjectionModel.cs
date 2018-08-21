using Jellyfish.DependencyInjection;

namespace Jellyfish.Demo.Injection
{
    public class InjectionModel
    {
        public InjectionModel()
        {
            Injector = new Injector();
        }

        private IInjector Injector { get; }

        public void ClearInjector()
        {
            Injector.Clear();
        }

        public IUser TemplateUser()
        {
            ClearInjector();
            Injector.Register<IUser>(() => new User());
            return Injector.Initialize<IUser>();
        }

        public IUser DefineUser()
        {
            ClearInjector();
            Injector.Register<IUser>(new User());
            return Injector.Initialize<IUser>();
        }

        public IUser BindUser()
        {
            ClearInjector();
            Injector.Register<IUser, User>("John", "Smith");
            return Injector.Initialize<IUser>();
        }
    }
}