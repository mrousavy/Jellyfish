using System;
using Jellyfish.DependencyInjection;

namespace Jellyfish.Attributes
{
    /// <inheritdoc />
    /// <summary>
    ///     Allow this property or field to be injected by the dependency <see cref="Injector" />
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class DependencyAttribute : Attribute
    { }
}