namespace Jellyfish.DependencyInjection
{
    /// <summary>
    ///     Extension methods for dependency injection resolving
    /// </summary>
    public static class InjectionExtensions
    {
        /// <summary>
        ///     Inject this object's dependencies
        /// </summary>
        /// <typeparam name="T">The type of the object</typeparam>
        /// <param name="reference">A reference of the object, or null if static</param>
        /// <param name="injector">The injector to use for resolving types</param>
        /// <exception cref="InjectorException">Thrown if some dependencies could not be resolved</exception>
        public static void Inject<T>(this T reference, IInjector injector)
        {
            InjectionResolver.InjectProperties(reference, injector);
            InjectionResolver.InjectFields(reference, injector);
        }

        /// <summary>
        ///     Create a new <see cref="IInjector"/> instance
        /// </summary>
        /// <returns>The newly initialized <see cref="IInjector"/> instance</returns>
        public static IInjector NewInjector() => new Injector();
    }
}
