using System;
using System.Collections.Generic;
using System.Linq;

namespace Jellyfish.DependencyInjection
{
    public class Injector : IInjector
    {
        /// <summary>
        ///     Initialize a new <see cref="Injector" /> instance
        /// </summary>
        public Injector()
        {
            Templates = new Dictionary<Type, Func<object>>();
        }

        private Dictionary<Type, Func<object>> Templates { get; }

        public void Register(Type baseType, Type subType, params object[] arguments)
        {
            if (Templates.ContainsKey(baseType))
            {
                throw new InjectorException($"This Injector already contains the type {baseType.Name}!");
            }

            if (!baseType.IsAssignableFrom(subType))
            {
                throw new ArgumentException($"The type {baseType.Name} is not assignable from {baseType.Name}!");
            }

            var types = arguments?.Select(a => a.GetType()).ToArray() ?? Type.EmptyTypes;
            var ctor = subType.GetConstructor(types);
            if (ctor == null)
            {
                throw new ArgumentException(
                    $"The type {subType.Name} does not have a public constructor with {types.Length} parameters to call!");
            }

            Templates.Add(baseType, () => ctor.Invoke(arguments));
        }

        public void Register<TBase, TSubtype>(params object[] arguments) where TSubtype : TBase =>
            Register(typeof(TBase), typeof(TSubtype), arguments);

        public void Register(Type baseType, Func<object> initializer)
        {
            if (Templates.ContainsKey(baseType))
            {
                throw new InjectorException($"This Injector already contains the type {baseType.Name}!");
            }

            Templates.Add(baseType, initializer);
        }

        public void Register<TBase>(Func<TBase> initializer) =>
            Register(typeof(TBase), initializer as Func<object>);

        public void Register<TBase>(TBase instance)
        {
            var type = typeof(TBase);
            if (Templates.ContainsKey(type))
            {
                throw new InjectorException($"This Injector already contains the type {type.Name}!");
            }

            Templates.Add(type, () => instance);
        }

        public void Remove<T>() => Remove(typeof(T));

        public void Remove(Type type)
        {
            Templates.Remove(type);
        }


        public TBase Initialize<TBase>()
        {
            var type = typeof(TBase);
            return (TBase) Initialize(type);
        }

        public object Initialize(Type type)
        {
            if (!Templates.ContainsKey(type))
            {
                throw new ArgumentException(
                    $"No implementations for the type {type.Name} could be found in the {nameof(Injector)}!");
            }

            var result = Templates[type]();
            if (result?.GetType() == type)
            {
                return result;
            }

            throw new InjectorException(
                $"Could not initialize type `{type.Name}`, the lambda returned an invalid type! ({result?.GetType()})");
        }

        public void Clear()
        {
            Templates.Clear();
        }
    }
}