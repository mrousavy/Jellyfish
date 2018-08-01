using System;

namespace Jellyfish.DependencyInjection
{
    /// <inheritdoc />
    /// <summary>
    ///     An exception that is thrown when the <see cref="T:Jellyfish.DependencyInjection.Injector" /> cannot successfully
    ///     template, bind or define a type
    /// </summary>
    public class InjectorException : Exception
    {
        public InjectorException(string message) : base(message)
        { }
    }
}