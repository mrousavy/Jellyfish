using System;
using System.Collections.Generic;
using System.Linq;

namespace Jellyfish.DependencyInjection
{
    /// <summary>
    ///     A Dependency Injection helper for declaring templates or definitions for types to be injected
    /// </summary>
    public class Injector
    {
        static Injector()
        {
            Instances = new Dictionary<Type, object>();
            Templates = new Dictionary<Type, Func<object>>();
        }

        private static Dictionary<Type, object> Instances { get; }
        private static Dictionary<Type, Func<object>> Templates { get; }

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
        public static void Bind(Type baseType, Type subType, params object[] arguments)
        {
            if (!baseType.IsAssignableFrom(subType))
                throw new ArgumentException($"The type {subType.Name} does not inherit from/implement {baseType.Name}");

            var types = arguments?.Select(a => a.GetType()).ToArray() ?? Type.EmptyTypes;
            var ctor = subType.GetConstructor(types);
            if (ctor == null)
                throw new ArgumentException(
                    $"The type {subType.Name} does not have a public constructor with {types.Length} parameters to call!");

            if (Templates.ContainsKey(baseType))
                Templates.Remove(baseType);
            Templates.AddOrUpdate(baseType, () => ctor.Invoke(arguments));
        }

        /// <summary>
        ///     Set the base type `<see cref="TBase" />` to use implementations of type `<see cref="TSubclass" />`
        /// </summary>
        /// <typeparam name="TBase">The type of the base ([abstract] class or interface)</typeparam>
        /// <typeparam name="TSubclass">The type of the sub-class (has to inherit from <see cref="TBase" />)</typeparam>
        /// <param name="arguments">
        ///     The arguments to use for the `<see cref="TSubclass" />` constructor call (or <code>null</code>
        ///     if none)
        /// </param>
        /// <exception cref="InjectorStoreException">
        ///     Thrown if the type `<see cref="TBase" />`/`<see cref="TSubclass" />` could not
        ///     be bound
        /// </exception>
        public static void Bind<TBase, TSubclass>(params object[] arguments) where TSubclass : TBase =>
            Bind(typeof(TBase), typeof(TSubclass), arguments);

        /// <summary>
        ///     Declare a template for the given type `<see cref="TBase" />` on how to initialize a variable spontaneously
        /// </summary>
        /// <typeparam name="TBase">The type of the property or field that gets injected</typeparam>
        /// <param name="initializer">The function to call everytime a property or field has to get initialized</param>
        /// <exception cref="InjectorStoreException">Thrown if the type `<see cref="TBase" />` could not be templated</exception>
        public static void Template<TBase>(Func<TBase> initializer)
        {
            Templates.AddOrUpdate(typeof(TBase), initializer as Func<object>);
        }

        /// <summary>
        ///     Declare a fixed variable for the given type `<see cref="TBase" />` to set all variables of type `
        ///     <see cref="TBase" />` to
        /// </summary>
        /// <typeparam name="TBase">The type of the property or field that gets injected</typeparam>
        /// <param name="instance">The static instance to initialize all variables of type `<see cref="TBase" />` with</param>
        /// <exception cref="InjectorStoreException">Thrown if the type `<see cref="TBase" />` could not be defined</exception>
        public static void Define<TBase>(TBase instance)
        {
            Instances.AddOrUpdate(typeof(TBase), instance);
        }

        /// <summary>
        ///     Initialize the given type `<see cref="TBase" />` with either a templated function to call or a pre-defined instance
        /// </summary>
        /// <typeparam name="TBase">The type of the object to initialize</typeparam>
        /// <exception cref="ArgumentException">
        ///     Thrown if the type `<see cref="TBase" />` could not be resolved as a known type to
        ///     the <see cref="Injector" />
        /// </exception>
        /// <returns>An initialized instance of type `<see cref="TBase" />`</returns>
        public static TBase Initialize<TBase>() where TBase : class
        {
            var type = typeof(TBase);

            if (Instances.ContainsKey(type))
                return Instances[type] as TBase;
            if (Templates.ContainsKey(type))
                return Templates[type]() as TBase;
            throw new ArgumentException(
                $"No implementations for the type {type.Name} could be found in the {nameof(Injector)}!");
        }

        /// <summary>
        ///     Initialize the given type `<see cref="type" />` with either a templated function to call or a pre-defined instance
        /// </summary>
        /// <param name="type">The type of the object to initialize</param>
        /// <exception cref="ArgumentException">
        ///     Thrown if the type `<see cref="type" />` could not be resolved as a known type to
        ///     the <see cref="Injector" />
        /// </exception>
        /// <returns>An initialized instance of type `<see cref="type" />`</returns>
        public static object Initialize(Type type)
        {
            if (Instances.ContainsKey(type))
                return Instances[type];
            if (Templates.ContainsKey(type))
                return Templates[type]();
            throw new ArgumentException(
                $"No implementations for the type {type.Name} could be found in the {nameof(Injector)}!");
        }
    }
}