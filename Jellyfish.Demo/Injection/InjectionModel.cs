using Jellyfish.DependencyInjection;

namespace Jellyfish.Demo.Injection
{
    public class InjectionModel
    {
        public IUser TemplateUser()
        {
            Injector.Template<IUser>(() => new User());
            return Injector.Initialize<IUser>();
        }

        public IUser DefineUser()
        {
            Injector.Define<IUser>(new User());
            return Injector.Initialize<IUser>();
        }

        public IUser BindUser()
        {
            Injector.Bind<IUser, User>();
            return Injector.Initialize<IUser>();
        }
    }
}
