using System.Collections.Generic;

namespace Grynwald.Utilities.Collections
{
    /// <summary>
    /// Represents a dictionary implemeting a 1:1 mapping of key and value
    /// which can be addressed in "both directions" ('key' -> 'value' as well as 'value' -> 'key')
    /// </summary>
    public interface IReversibleDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        /// <summary>
        /// Gets the reversed dictionary that contains the same items but with key and value swapped
        /// </summary>
        IReversibleDictionary<TValue, TKey> ReversedDictionary { get; }
    }
}