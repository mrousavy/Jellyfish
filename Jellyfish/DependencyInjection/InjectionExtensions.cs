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
        /// <exception cref="InjectorStoreException">Thrown if some dependencies could not be resolved</exception>
        public static void Inject<T>(this T reference, Injector injector)
        {
            InjectionResolver.InjectProperties(reference, injector);
            InjectionResolver.InjectFields(reference, injector);
        }
    }
}
