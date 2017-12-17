using System.Collections.Generic;

namespace Grynwald.Utilities.Collections
{
    public interface IReversibleDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        /// <summary>
        ///     Gets the reversed dictionary that contains the same items but with key and value swapped
        /// </summary>
        IReversibleDictionary<TValue, TKey> ReversedDictionary { get; }
    }
}