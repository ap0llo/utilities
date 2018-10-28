using System;
using System.Collections.Generic;

namespace Grynwald.Utilities.Collections
{
    /// <summary>
    /// Extension methods for <see cref="IDictionary{TKey, TValue}"/>
    /// </summary>
    public static class DictionaryExtensions
    {     
        /// <summary>
        /// Tries to get the element with the specified key.
        /// If the dictionary does not contain a matching element, default(TValie) is returned
        /// </summary>
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue))
        {
            return dictionary.ContainsKey(key)
                ? dictionary[key]
                : defaultValue;
        }

        /// <summary>
        /// Tries to get the element with the specified key from the dictionary.
        /// If no matching element is found, a value is created using the specified factory function
        /// and added to the dictionary
        /// </summary>
        /// <param name="dictionary">The dictionary to get the value from</param>
        /// <param name="key">The key to search for</param>
        /// <param name="factory">The factory function to create a new value for the case that no value can be found</param>
        /// <returns>
        /// Returns the item for the specified key if the dictionary already contained the key.
        /// Otherwise returns the newly added item returned by <paramref name="factory"/>
        /// </returns>
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> factory)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (factory == null)
                throw new ArgumentNullException(nameof(factory));


            if (dictionary.TryGetValue(key, out var value))
            {
                return value;
            }
            else
            {
                value = factory();
                dictionary.Add(key, value);
                return value;
            }
        }
    }
}
