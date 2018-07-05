using System;

namespace Jellyfish.DependencyInjection
{
    /// <summary>
    ///     A Dependency Injection helper for declaring templates or definitions for types to be injected
    /// </summary>
    public interface IInjector
    {
        /// <summary>
        ///     Set the base type `<see cref="baseType" />` to use implementations of type `<see cref="subType" />`
        /// </summary>
        /// <param name="baseType">The type of the base ([abstract] class or interface)</param>
        /// <param name="subType">The type of the sub-class (has to inherit from <see cref="baseType" />)</param>
        /// <param name="arguments">
        ///     The arguments to use for the `<see cref="subType" />` constructor call (or <code>null</code> if
        ///     none)
        /// </param>
        /// <exception cref="InjectorStoreException">
        ///     Thrown if the type `<see cref="baseType" />`/`<see cref="subType" />` could
        ///     not be bound
        /// </exception>
        void Bind(Type baseType, Type subType, params object[] arguments);

        /// <summary>
        ///     Set the base type `<see cref="TBase" />` to use implementations of type `<see cref="TSubtype" />`
        /// </summary>
        /// <typeparam name="TBase">The type of the base ([abstract] class or interface)</typeparam>
        /// <typeparam name="TSubtype">The type of the sub-class (has to inherit from <see cref="TBase" />)</typeparam>
        /// <param name="arguments">
        ///     The arguments to use for the `<see cref="TSubtype" />` constructor call (or <code>null</code>
        ///     if none)
        /// </param>
        /// <exception cref="InjectorStoreException">
        ///     Thrown if the type `<see cref="TBase" />`/`<see cref="TSubtype" />` could not
        ///     be bound
        /// </exception>
        void Bind<TBase, TSubtype>(params object[] arguments) where TSubtype : TBase;

        /// <summary>
        ///     Declare a template for the given type `<see cref="TBase" />` on how to initialize a variable spontaneously
        /// </summary>
        /// <typeparam name="TBase">The type of the property or field that gets injected</typeparam>
        /// <param name="initializer">The function to call everytime a property or field has to get initialized</param>
        /// <exception cref="InjectorStoreException">Thrown if the type `<see cref="TBase" />` could not be templated</exception>
        void Template<TBase>(Func<TBase> initializer);

        /// <summary>
        ///     Declare a template for the given type `<see cref="baseType" />` on how to initialize a variable spontaneously
        /// </summary>
        /// <param name="baseType">The type of the property or field that gets injected</param>
        /// <param name="initializer">The function to call everytime a property or field has to get initialized</param>
        /// <exception cref="InjectorStoreException">Thrown if the type `<see cref="baseType" />` could not be templated</exception>
        void Template(Type baseType, Func<object> initializer);

        /// <summary>
        ///     Declare a fixed variable for the given type `<see cref="TBase" />` to set all variables of type `
        ///     <see cref="TBase" />` to
        /// </summary>
        /// <typeparam name="TBase">The type of the property or field that gets injected</typeparam>
        /// <param name="instance">The static instance to initialize all variables of type `<see cref="TBase" />` with</param>
        /// <exception cref="InjectorStoreException">Thrown if the type `<see cref="TBase" />` could not be defined</exception>
        void Define<TBase>(TBase instance);




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
        ///     Clear all templates, definitions and bindings in this <see cref="Injector"/>
        /// </summary>
        void Clear();
    }
}
