using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Jellyfish.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        ///     Convert this <see cref="IEnumerable{T}" /> into an <see cref="ObservableCollection{T}" />
        /// </summary>
        /// <typeparam name="T">The type of the lists</typeparam>
        /// <param name="enumerable">The enumerable itself</param>
        /// <returns>A newly created observable collection</returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerable) =>
            new ObservableCollection<T>(enumerable);
    }
}