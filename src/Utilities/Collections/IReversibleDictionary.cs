using System.Collections.Generic;

namespace Grynwald.Utilities.Collections
{
    /// <summary>
    /// Represents a dictionary implementing a 1:1 mapping of keys and values
    /// which can be addressed in "both directions" ('key' -> 'value' as well as 'value' -> 'key')
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
    /// <seealso cref="ReversibleDictionary{TKey, TValue}"/>
    public interface IReversibleDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        /// <summary>
        /// Gets the reversed dictionary that contains the same items but with keys and values swapped.
        /// </summary>
        IReversibleDictionary<TValue, TKey> ReversedDictionary { get; }
    }
}
