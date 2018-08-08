using System;
using System.Collections.Generic;

namespace Jellyfish.References
{
    /// <summary>
    ///     An interface for keeping track of <c>n</c> references of type <see cref="TReference"/> using weak references
    /// </summary>
    /// <typeparam name="TReference">The type of the reference</typeparam>
    public interface IReferenceManager<TReference> where TReference : class
    {
        /// <summary>
        ///     Register a new reference in the <see cref="IReferenceManager{TReference}"/>. Once this reference is garbage collected, it will be automatically removed
        /// </summary>
        /// <param name="reference">The reference</param>
        void Register(TReference reference);

        /// <summary>
        ///     A list of all references this <see cref="IReferenceManager{TReference}"/> currently keeps track of
        /// </summary>
        IList<IReference<TReference>> References { get; }

        /// <summary>
        ///     Get the <see cref="IReference{TReference}"/> to the given reference
        /// </summary>
        /// <param name="reference">The actual reference used as an index</param>
        /// <returns>The found <see cref="IReference{TReference}"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown if the given reference is not registered in this <see cref="IReferenceManager{TReference}"/>
        /// </exception>
        IReference<TReference> this[TReference reference] { get; }
    }
}
