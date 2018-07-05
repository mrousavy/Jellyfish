using System;
using System.Collections.Generic;
using System.Linq;
using Jellyfish.Extensions;

namespace Jellyfish.DependencyInjection
{
    public class Injector : IInjector
    {
        /// <summary>
        ///     Initialize a new <see cref="Injector"/> instance
        /// </summary>
        public Injector()
        {
            Instances = new Dictionary<Type, object>();
            Templates = new Dictionary<Type, Func<object>>();
        }

        private Dictionary<Type, object> Instances { get; }
        private Dictionary<Type, Func<object>> Templates { get; }

        public void Bind(Type baseType, Type subType, params object[] arguments)
        {
            if (!baseType.IsAssignableFrom(subType))
                throw new ArgumentException($"The type {subType.Name} does not inherit from/implement {baseType.Name}");

            var types = arguments?.Select(a => a.GetType()).ToArray() ?? Type.EmptyTypes;
            var ctor = subType.GetConstructor(types);
            if (ctor == null)
                throw new ArgumentException(
                    $"The type {subType.Name} does not have a public constructor with {types.Length} parameters to call!");

            Templates.AddOrUpdate(baseType, () => ctor.Invoke(arguments));
        }

        public void Bind<TBase, TSubtype>(params object[] arguments) where TSubtype : TBase =>
            Bind(typeof(TBase), typeof(TSubtype), arguments);

        public void Template<TBase>(Func<TBase> initializer)
        {
            Templates.AddOrUpdate(typeof(TBase), initializer as Func<object>);
        }

        public void Template(Type baseType, Func<object> initializer)
        {
            Templates.AddOrUpdate(baseType, initializer);
        }

        public void Define<TBase>(TBase instance)
        {
            Instances.AddOrUpdate(typeof(TBase), instance);
        }



        public TBase Initialize<TBase>()
        {
            var type = typeof(TBase);
            return (TBase) Initialize(type);
        }

        public object Initialize(Type type)
        {
            if (Instances.ContainsKey(type))
                return Instances[type];
            if (Templates.ContainsKey(type))
                return Templates[type]();
            throw new ArgumentException(
                $"No implementations for the type {type.Name} could be found in the {nameof(Injector)}!");
        }

        public void Clear()
        {
            Templates.Clear();
            Instances.Clear();
        }
    }
}