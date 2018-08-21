using Jellyfish.DependencyInjection;
using $safeprojectname$.Main;

namespace $safeprojectname$
{
	public class ViewModelLocator
    {
        public MainViewModel MainViewModel => InjectionResolver.InjectConstructor<MainViewModel>(Instances.Injector);
    }
}
