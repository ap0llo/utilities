using System;
using System.Collections.Generic;


namespace Grynwald.Utilities.Collections
{
    public static class DictionaryExtensions
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue))
        {
            return dictionary.ContainsKey(key)
                ? dictionary[key]
                : defaultValue;
        }


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
