using Jellyfish.DependencyInjection;

namespace $rootnamespace$
{
    public static class Instances
    {
        private static IInjector _injector;
        public static IInjector Injector => _injector ?? (_injector = new Injector());
    }
}
