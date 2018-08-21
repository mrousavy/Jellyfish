using System.Collections.Generic;

namespace Jellyfish.Extensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        ///     Add an element to the <see cref="dictionary" />, if it already exists, update it's value
        /// </summary>
        /// <typeparam name="TKey">The type of the key in the dictionary</typeparam>
        /// <typeparam name="TValue">The type of the value in the dictionary</typeparam>
        /// <param name="dictionary">The dictionary to perform the <see cref="AddOrUpdate{TKey,TValue}" /> on</param>
        /// <param name="key">The key to the existing or new value</param>
        /// <param name="value">The key of the new value</param>
        public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = value;
            } else
            {
                dictionary.Add(key, value);
            }
        }
    }
}