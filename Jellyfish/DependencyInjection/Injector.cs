using System;
using System.Collections.Generic;

namespace Jellyfish.DependencyInjection
{
    /// <summary>
    ///     A Dependency Injection helper for declaring templates or definitions for types to be injected
    /// </summary>
    public class Injector
    {
        public static Dictionary<Type, Type> Bindings { get; }
        public static Dictionary<Type, object> Instances { get; }

        static Injector()
        {
            Bindings = new Dictionary<Type, Type>();
            Instances = new Dictionary<Type, object>();
        }

        /// <summary>
        ///     Set the base type `<see cref="baseType"/>` to use implementations of type `<see cref="subType"/>`
        /// </summary>
        /// <param name="baseType">The type of the base ([abstract] class or interface)</param>
        /// <param name="subType">The type of the sub-class (has to inherit from <see cref="baseType"/>)</param>
        public static void Bind(Type baseType, Type subType)
        {
            if(!subType.IsSubclassOf(baseType))
                throw new ArgumentException($"The type {subType.Name} does not inherit from {baseType.Name}");
            Bindings.Add(baseType, subType);
        }

        /// <summary>
        ///     Set the base type `<see cref="TBase"/>` to use implementations of type `<see cref="TSubclass"/>`
        /// </summary>
        /// <typeparam name="TBase">The type of the base ([abstract] class or interface)</typeparam>
        /// <typeparam name="TSubclass">The type of the sub-class (has to inherit from <see cref="TBase"/>)</typeparam>
        public static void Bind<TBase, TSubclass>() where TSubclass : TBase => Bind(typeof(TBase), typeof(TSubclass));

        /// <summary>
        ///     Declare a template for the given type `<see cref="TBase"/>` on how to initialize a variable spontaneously
        /// </summary>
        /// <typeparam name="TBase">The type of the property or field that gets injected</typeparam>
        /// <param name="initializer">The function to call everytime a property or field has to get initialized</param>
        public static void Template<TBase>(Func<TBase> initializer)
        {
            Console.WriteLine("template");
        }

        /// <summary>
        ///     Declare a fixed variable for the given type `<see cref="TBase"/>` to set all variables of type `<see cref="TBase"/>` to
        /// </summary>
        /// <typeparam name="TBase">The type of the property or field that gets injected</typeparam>
        /// <param name="instance">The static instance to initialize all variables of type `<see cref="TBase"/>` with</param>
        public static void Define<TBase>(TBase instance)
        {
            Bind<IFeed<string>, MessageFeed<string>>();
            Instances.Add(typeof(TBase), instance);
        }
    }
}
