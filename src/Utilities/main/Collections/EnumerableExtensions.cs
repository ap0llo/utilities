using System;
using System.Collections.Generic;
using System.Linq;

namespace Grynwald.Utilities.Collections
{
    /// <summary>
    /// Extnension methods for <see cref="IEnumerable{T}"/>
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Concatenates the items in the specified enumerable to a string
        /// </summary>        
        public static string JoinToString(this IEnumerable<object> values) => JoinToString(values, ",");

        /// <summary>
        /// Concatenates the items in the specified enumerable to a string using the specified separator
        /// </summary>        
        public static string JoinToString(this IEnumerable<object> values, string separator) => String.Join(separator, values.ToArray());

        /// <summary>
        /// Returns a new enumerable containing the item
        /// </summary>
        public static IEnumerable<T> Yield<T>(this T item)
        {
            yield return item;
        }

        /// <summary>
        /// Adds the specified item at the end of the enumerable 
        /// </summary>
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> enumerable, T newItem)
        {
            return enumerable.Concat(newItem.Yield());
        }

        /// <summary>
        /// Creates a new <see cref="HashSet{T}"/> with elements copied from the enumerable
        /// using the default equality comparer
        /// </summary>
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> enumerable) => new HashSet<T>(enumerable);

        /// <summary>
        /// Creates a new <see cref="HashSet{T}"/> with elements copied from the enumerable
        /// using the specified equality comparer
        /// </summary>
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> enumerable, IEqualityComparer<T> comparer) =>
            new HashSet<T>(enumerable, comparer);

        /// <summary>
        /// Determines if two sequences contain the same set of elements (in any order)
        /// </summary>
        /// <remarks>Iterates over both enumerables</remarks>
        public static bool SetEqual<T>(this IEnumerable<T> enumerable, IEnumerable<T> other) =>
            enumerable.ToHashSet().SetEquals(other);
    }
}
