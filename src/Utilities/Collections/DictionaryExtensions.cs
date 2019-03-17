﻿using System;
using System.Collections.Generic;

namespace Grynwald.Utilities.Collections
{
    /// <summary>
    /// Extension methods for <see cref="IDictionary{TKey, TValue}"/>.
    /// </summary>
    public static class DictionaryExtensions
    {

        /// <summary>
        /// Tries to get the element with the specified key.
        /// If the dictionary does not contain a matching element, <c>default(TValue)</c> is returned
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary to retrieve the value from.</param>
        /// <param name="key">The key to locate in the dictionary.</param>
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) => dictionary.GetValueOrDefault(key, default);

        /// <summary>
        /// Tries to get the element with the specified key.
        /// If the dictionary does not contain a matching element, the value of <paramref name="defaultValue"/> is returned.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary to retrieve the value from.</param>
        /// <param name="key">The key to locate in the dictionary.</param>
        /// <param name="defaultValue">The value to return if the dictionary does not contain an item with the specified key.</param>
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            return dictionary.ContainsKey(key)
                ? dictionary[key]
                : defaultValue;
        }

        // GetValueOrDefault was added in .NET Core 2.0.
        // Exclude the method from the reference assembly for .NET Core 2.0,
        // so a project targeting netcoreapp2.0, uses the built-in method
#if !(REFERENCE_ASSEMBLY && NETCOREAPP2_0)

        /// <summary>
        /// Tries to get the element with the specified key.
        /// If the dictionary does not contain a matching element, default(TValue) is returned
        /// </summary>
        /// <remarks>
        /// This method is not included in the reference assembly for .NET Core 2.0 or later
        /// because a equivalent extension method, is available there
        /// and using the built-in method is preferable.
        /// </remarks>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary to retrieve the value from.</param>
        /// <param name="key">The key to locate in the dictionary.</param>
        public static TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key) => dictionary.GetValueOrDefault(key, default);

        /// <summary>
        /// Tries to get the element with the specified key.
        /// If the dictionary does not contain a matching element, <c>default(TValue)</c> is returned
        /// </summary>
        /// <remarks>
        /// This method is not included in the reference assembly for .NET Core 2.0 or later
        /// because a equivalent extension method, is available there
        /// and using the built-in method is preferable.
        /// </remarks>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary to retrieve the value from.</param>
        /// <param name="key">The key to locate in the dictionary.</param>
        /// <param name="defaultValue">The value to return if the dictionary does not contain an item with the specified key.</param>
        public static TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            return dictionary.ContainsKey(key)
                ? dictionary[key]
                : defaultValue;
        }

#endif

        /// <summary>
        /// Tries to get the element with the specified key from the dictionary.
        /// If no matching element is found, a value is created using the specified factory function
        /// and added to the dictionary
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
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
