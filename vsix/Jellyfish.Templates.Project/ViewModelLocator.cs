using System.Windows;
using Jellyfish;
using Jellyfish.DependencyInjection;
using $rootnamespace$.Main;

namespace $rootnamespace$
{
	public class ViewModelLocator
    {
        public MainViewModel MainViewModel => InjectionResolver.InjectConstructor<MainViewModel>(Instances.Injector);
    }
}
