using System;

namespace Jellyfish.Attributes
{
    // TODO: Implementation attribute?

    /// <inheritdoc />
    /// <summary>
    ///     Defines the implementation class of the property or field this attribute is applied on
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    internal class ImplementationAttribute : Attribute
    {
        /// <inheritdoc />
        /// <summary>
        ///     Initialize a new dependency using automatic injector binding initialization by calling the constructor with the
        ///     given <see cref="parameters" /> (or none for default)
        /// </summary>
        /// <param name="implementationType">The type to use for automatically initializing this dependency</param>
        /// <param name="parameters">
        ///     The parameters to use for calling the <see cref="implementationType" />'s constructor (or none
        ///     for default)
        /// </param>
        public ImplementationAttribute(Type implementationType, params object[] parameters)
        {
            ImplementationType = implementationType;
            Parameters = parameters;
        }

        public Type ImplementationType { get; }
        public object[] Parameters { get; }
    }
}