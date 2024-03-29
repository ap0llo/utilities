﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Grynwald.Utilities.Collections
{
    /// <summary>
    /// Extension methods for <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Concatenates the items in the specified enumerable to a string.
        /// </summary>
        /// <param name="values">The value to concatenate.</param>
        public static string JoinToString(this IEnumerable<object> values) => JoinToString(values, ",");

        /// <summary>
        /// Concatenates the items in the specified enumerable to a string using the specified separator.
        /// </summary>
        /// <param name="values">The value to concatenate.</param>
        /// <param name="separator">The separator to insert between elements of <paramref name="values"/>.</param>
        public static string JoinToString(this IEnumerable<object> values, string separator) => String.Join(separator, values.ToArray());

        /// <summary>
        /// Returns a new enumerable containing the specified item.
        /// </summary>
        /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
        /// <param name="item">The item to return as enumerable.</param>
        /// <returns>
        /// Returns a new enumerable containing only a single item.
        /// </returns>
        public static IEnumerable<T> Yield<T>(this T item)
        {
            yield return item;
        }

        /// <summary>
        /// Adds the specified item at the end of the enumerable.
        /// </summary>
        /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
        /// <param name="enumerable">The enumerable to add the item to.</param>
        /// <param name="newItem">The item to append to the enumerable.</param>
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> enumerable, T newItem)
        {
            return enumerable.Concat(newItem.Yield());
        }

        // ToHashSet exists in .NET Core 2.0, .NET Standard 2.1 and .NET Framework 4.7.2
        // Exclude the method from the reference assembly for these target frameworks
        // so a project targeting these frameworks, uses the built-in method
#if !(REFERENCE_ASSEMBLY && (NETCOREAPP2_0_OR_GREATER|| NET472_OR_GREATER || NETSTANDARD2_1_OR_GREATER))

        /// <summary>
        /// Creates a new <see cref="HashSet{T}"/> with elements copied from the enumerable
        /// using the default equality comparer.
        /// </summary>
        /// <remarks>
        /// This method is not included in the reference assembly for the following frameworks
        /// because a equivalent extension method, is available there and using the built-in method is preferable:
        /// <list type="bullet">
        ///     <item><description>.NET Core 2.0 or later</description></item>
        ///     <item><description>.NET Framework 4.7.2 or later</description></item>
        ///     <item><description>.NET Standard 2.1 or later</description></item>
        /// </list>       
        /// </remarks>
        /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
        /// <param name="enumerable">The collection of items to copy to the set.</param>
        [HiddenFromReferenceAssembly("net472")]
        [HiddenFromReferenceAssembly("netcoreapp3.1")]
        [HiddenFromReferenceAssembly("netstandard2.1")]
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> enumerable) => new HashSet<T>(enumerable);

        /// <summary>
        /// Creates a new <see cref="HashSet{T}"/> with elements copied from the enumerable
        /// using the specified equality comparer.
        /// </summary>
        /// <remarks>
        /// This method is not included in the reference assembly for the following frameworks
        /// because a equivalent extension method, is available there and using the built-in method is preferable:
        /// <list type="bullet">
        ///     <item><description>.NET Core 2.0 or later</description></item>
        ///     <item><description>.NET Framework 4.7.2 or later</description></item>
        ///     <item><description>.NET Standard 2.1 or later</description></item>
        /// </list>       
        /// </remarks>
        /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
        /// <param name="enumerable">The collection of items to copy to the set.</param>
        /// <param name="comparer">The comparer to use for creating the set.</param>
        [HiddenFromReferenceAssembly("net472")]
        [HiddenFromReferenceAssembly("netcoreapp3.1")]
        [HiddenFromReferenceAssembly("netstandard2.1")]
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> enumerable, IEqualityComparer<T> comparer) =>
            new HashSet<T>(enumerable, comparer);

#endif

        /// <summary>
        /// Determines if two sequences contain the same set of elements (in any order)
        /// </summary>
        /// <remarks>Comparing sets will enumerate both enumerables.</remarks>
        public static bool SetEqual<T>(this IEnumerable<T> enumerable, IEnumerable<T> other) =>
            enumerable.ToHashSet().SetEquals(other);
    }
}
