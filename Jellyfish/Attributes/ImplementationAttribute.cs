using System;

namespace Jellyfish.Attributes
{
    /// <inheritdoc />
    /// <summary>
    ///     Defines the implementation class of the property or field this attribute is applied on
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ImplementationAttribute : Attribute
    {
        public ImplementationAttribute(Type implementationType)
        {
            ImplementationType = implementationType;
        }

        /// <summary>
        ///     The type of the implementation class of the interface
        /// </summary>
        public Type ImplementationType { get; }
    }
}