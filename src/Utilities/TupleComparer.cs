using System.Collections.Generic;

namespace Grynwald.Utilities
{
    /// <summary>
    /// Utility class to ease instantiation of <see cref="TupleComparer{T1, T2}"/> and <see cref="TupleComparer{T1, T2, T3}"/>.
    /// </summary>
    /// <seealso cref="TupleComparer{T1, T2}"/>
    /// <seealso cref="TupleComparer{T1, T2, T3}"/>
    public static class TupleComparer
    {
        /// <summary>
        /// Creates a new comparer for tuples with two elements.
        /// </summary>
        /// <typeparam name="T1">The type of the tuple's first element.</typeparam>
        /// <typeparam name="T2">The type of the tuple's second element.</typeparam>
        /// <param name="firstItemComparer">The comparer to use for comparison of the tuple's first item.</param>
        /// <param name="secondItemComparer">The comparer to use for comparison of the tuple's second item.</param>
        /// <returns>Returns a new instance of <see cref="TupleComparer{T1, T2}"/> with the specified comparers.</returns>
        /// <seealso cref="TupleComparer{T1, T2}.TupleComparer(IEqualityComparer{T1}, IEqualityComparer{T2})"/>
        public static TupleComparer<T1, T2> Create<T1, T2>(
            IEqualityComparer<T1> firstItemComparer,
            IEqualityComparer<T2> secondItemComparer) => new TupleComparer<T1, T2>(firstItemComparer, secondItemComparer);

        /// <summary>
        /// Creates a new comparer for tuples with three elements.
        /// </summary>
        /// <typeparam name="T1">The type of the tuple's first element.</typeparam>
        /// <typeparam name="T2">The type of the tuple's second element.</typeparam>
        /// <typeparam name="T3">The type of the tuple's third element.</typeparam>
        /// <param name="firstItemComparer">The comparer to use for comparison of the tuple's first item.</param>
        /// <param name="secondItemComparer">The comparer to use for comparison of the tuple's second item.</param>
        /// <param name="thirdItemComparer">The comparer to use for comparison of the tuple's third item.</param>
        /// <returns>Returns a new instance of <see cref="TupleComparer{T1, T2, T3}"/> with the specified comparers.</returns>
        /// <seealso cref="TupleComparer{T1, T2, T3}.TupleComparer(IEqualityComparer{T1}, IEqualityComparer{T2}, IEqualityComparer{T3})"/>
        public static TupleComparer<T1, T2, T3> Create<T1, T2, T3>(
            IEqualityComparer<T1> firstItemComparer,
            IEqualityComparer<T2> secondItemComparer,
            IEqualityComparer<T3> thirdItemComparer) => new TupleComparer<T1, T2, T3>(firstItemComparer, secondItemComparer, thirdItemComparer);
    }
}
