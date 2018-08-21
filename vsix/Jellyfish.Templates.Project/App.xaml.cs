using System.Windows;
using Jellyfish.DependencyInjection;
using $safeprojectname$.Main;

namespace $safeprojectname$
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Build();
        }

        public void Build()
        {
            Instances.Injector.Register(() => new MainViewModel());
        }
    }
}