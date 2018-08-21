namespace Jellyfish.References
{
    /// <summary>
    ///     Represents a weak reference to a specific field
    /// </summary>
    /// <typeparam name="TReference"></typeparam>
    public interface IReference<out TReference> where TReference : class
    {
        /// <summary>
        ///     The actual vaue of the reference (or null if the reference has been garbage collected)
        /// </summary>
        TReference Value { get; }

        /// <summary>
        ///     Determines wether the reference to the <see cref="Value"/> still is valid
        /// </summary>
        bool IsValid { get; }
    }
}
