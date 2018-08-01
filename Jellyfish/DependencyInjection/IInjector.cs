using System;

namespace Jellyfish.DependencyInjection
{
    /// <summary>
    ///     A Dependency Injection helper for declaring templates or definitions for types to be injected
    /// </summary>
    public interface IInjector
    {
        /// <summary>
        ///     Register the type `<see cref="baseType" />` to use new instances of type `<see cref="subType" />` for injection
        ///     (binding)
        /// </summary>
        /// <param name="baseType">The type of the base ([abstract] class or interface)</param>
        /// <param name="subType">The type of the sub-class (has to inherit from <see cref="baseType" />)</param>
        /// <param name="arguments">
        ///     The arguments to use for the `<see cref="subType" />` constructor call (or <code>null</code> if
        ///     none)
        /// </param>
        /// <exception cref="InjectorException">
        ///     Thrown if the type `<see cref="baseType" />`/`<see cref="subType" />` could
        ///     not be bound
        /// </exception>
        void Register(Type baseType, Type subType, params object[] arguments);

        /// <summary>
        ///     Register the type `<see cref="TBase" />` to use new instances of type `<see cref="TSubtype" />` for injection
        ///     (binding)
        /// </summary>
        /// <typeparam name="TBase">The type of the base ([abstract] class or interface)</typeparam>
        /// <typeparam name="TSubtype">The type of the sub-class (has to inherit from <see cref="TBase" />)</typeparam>
        /// <param name="arguments">
        ///     The arguments to use for the `<see cref="TSubtype" />` constructor call (or <code>null</code>
        ///     if none)
        /// </param>
        /// <exception cref="InjectorException">
        ///     Thrown if the type `<see cref="TBase" />`/`<see cref="TSubtype" />` could not
        ///     be bound
        /// </exception>
        void Register<TBase, TSubtype>(params object[] arguments) where TSubtype : TBase;

        /// <summary>
        ///     Register the type `<see cref="TBase" />` to use the result of the `<see cref="initializer" />` function for
        ///     injection (templating)
        /// </summary>
        /// <typeparam name="TBase">The type of the property or field that gets injected</typeparam>
        /// <param name="initializer">The function to call everytime a property or field has to get initialized</param>
        /// <exception cref="InjectorException">Thrown if the type `<see cref="TBase" />` could not be templated</exception>
        void Register<TBase>(Func<TBase> initializer);

        /// <summary>
        ///     Register the type `<see cref="baseType" />` to use the result of the `<see cref="initializer" />` function for
        ///     injection (templating)
        /// </summary>
        /// <param name="baseType">The type of the property or field that gets injected</param>
        /// <param name="initializer">The function to call everytime a property or field has to get initialized</param>
        /// <exception cref="InjectorException">Thrown if the type `<see cref="baseType" />` could not be templated</exception>
        void Register(Type baseType, Func<object> initializer);

        /// <summary>
        ///     Register the type `<see cref="T" />` to always use the pre-defined variable `<see cref="instance" />` for injection
        ///     (defining)
        /// </summary>
        /// <typeparam name="T">The type of the property or field that gets injected</typeparam>
        /// <param name="instance">The static instance to initialize all variables of type `<see cref="T" />` with</param>
        /// <exception cref="InjectorException">Thrown if the type `<see cref="T" />` could not be defined</exception>
        void Register<T>(T instance);


        /// <summary>
        ///     Remove the registered type `<see cref="T" />` from this <see cref="IInjector" /> instance
        /// </summary>
        /// <typeparam name="T">The type to remove</typeparam>
        void Remove<T>();

        /// <summary>
        ///     Remove the registered type `<see cref="type" />` from this <see cref="IInjector" /> instance
        /// </summary>
        /// <param name="type">The type to remove</param>
        void Remove(Type type);


        /// <summary>
        ///     Initialize the given type `<see cref="TBase" />` with either a templated function to call or a pre-defined instance
        /// </summary>
        /// <typeparam name="TBase">The type of the object to initialize</typeparam>
        /// <exception cref="ArgumentException">
        ///     Thrown if the type `<see cref="TBase" />` could not be resolved as a known type to
        ///     the <see cref="Injector" />
        /// </exception>
        /// <returns>An initialized instance of type `<see cref="TBase" />`</returns>
        TBase Initialize<TBase>();

        /// <summary>
        ///     Initialize the given type `<see cref="type" />` with either a templated function to call or a pre-defined instance
        /// </summary>
        /// <param name="type">The type of the object to initialize</param>
        /// <exception cref="ArgumentException">
        ///     Thrown if the type `<see cref="type" />` could not be resolved as a known type to
        ///     the <see cref="Injector" />
        /// </exception>
        /// <returns>An initialized instance of type `<see cref="type" />`</returns>
        object Initialize(Type type);

        /// <summary>
        ///     Clear all registered types in this <see cref="IInjector" /> instance
        /// </summary>
        void Clear();
    }
}