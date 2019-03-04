using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Grynwald.Utilities.Collections
{
    /// <summary>
    /// Singleton implementation of <see cref="IReadOnlyDictionary{TKey, TValue}"/> .
    /// </summary>
    /// <remarks>
    /// <see cref="ReadOnlyDictionary{TKey, TValue}"/> provides a empty singleton dictionary
    /// analogous to <see cref="Array.Empty{T}"/>
    /// </remarks>
    /// <example><![CDATA[
    /// public void Method1(IReadOnlyDictionary<string, string> dictionary = null)
    /// {
    ///     dictionary = dictionary ?? ReadOnlyDictionar<string, string>.Empty;
    /// }
    /// ]]>
    /// </example>
    /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
    public class ReadOnlyDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>
    {
        /// <summary>
        /// The singleton instance of <see cref="ReadOnlyDictionary{TKey, TValue}"/>
        /// </summary>
        public static IReadOnlyDictionary<TKey, TValue> Empty = new ReadOnlyDictionary<TKey, TValue>();


        public TValue this[TKey key] => throw new KeyNotFoundException();

        public IEnumerable<TKey> Keys => Enumerable.Empty<TKey>();

        public IEnumerable<TValue> Values => Enumerable.Empty<TValue>();

        public int Count => 0;

        public bool ContainsKey(TKey key) => false;

        private ReadOnlyDictionary()
        { }


        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => Enumerable.Empty<KeyValuePair<TKey, TValue>>().GetEnumerator();

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default;
            return false;            
        }

        IEnumerator IEnumerable.GetEnumerator() => Enumerable.Empty<KeyValuePair<TKey, TValue>>().GetEnumerator();
    }
}
