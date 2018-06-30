using System;

namespace Jellyfish.Attributes
{
    /// <inheritdoc />
    /// <summary>
    ///     Specify the implementation to use for injecting this property
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class DependencyAttribute : Attribute
    {
        /// <inheritdoc />
        /// <summary>
        ///     Initialize a new dependency using automatic injector binding initialization by calling the constructor with the given <see cref="parameters"/> (or none for default)
        /// </summary>
        /// <param name="implementationType">The type to use for automatically initializing this dependency</param>
        /// <param name="parameters">The parameters to use for calling the <see cref="implementationType"/>'s constructor (or none for default)</param>
        public DependencyAttribute(Type implementationType, params object[] parameters)
        {
            ImplementationType = implementationType;
            Parameters = parameters;
        }

        public Type ImplementationType { get; }
        public object[] Parameters { get; }
    }
}